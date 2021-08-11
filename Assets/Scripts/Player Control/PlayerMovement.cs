/*
Nombre del desarrollador: Emilio Ceballos Castro
Asignatura: Programación Orientada a Objetos
Fuente en la que se basa el scripts: Canal de Youtube Pandemonium games
Descripción general: Script usado para el movimiento de personaje al igual que guarda informacion 
sobre condiciones de ataque y salto de paredes
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        horizontalInput=Input.GetAxis("Horizontal");
        
        //Voltea al sprite al moverse de un lado al otro
        if(horizontalInput > 0.01f)
        {
            transform.localScale=Vector3.one;
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale=new Vector3(-1,1,1);
        }

        anim.SetBool("Run",horizontalInput!=0);
        anim.SetBool("Grounded", isGrounded());

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Crouch",true);
        }else
        {
            anim.SetBool("Crouch",false);
        }

        //Codigo para generar el wall jump
        if (wallJumpCooldown > 0.2f)
        {
            

          body.velocity=new Vector2(horizontalInput*speed, body.velocity.y);

          //Usado para saber si el personaje esta en una pared y en el piso
          if (onWall() && !isGrounded())
          {
              body.gravityScale=0;
              body.velocity=Vector2.zero;
          }
          else
          {
              body.gravityScale=3;
          }
          
          if(Input.GetKey(KeyCode.Space))
          {
             Jump();
          }
          
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }


    private void Jump()
    {
        //Esta variable es usada para que detecte cuando este en el piso con una etiqueta en el piso
        if(isGrounded())
        {
         body.velocity=new Vector2(body.velocity.x, jumpForce);
         anim.SetTrigger("Jump");
        }
        else if (onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity=new Vector2(-Mathf.Sign(transform.localScale.x) * 6,0);
                transform.localScale=new Vector3 (-Mathf.Sign(transform.localScale.x), transform.localScale.y,transform.localScale.z);
            }
            else
            {
            //Esto hace que el jugador sea empujado al lado opuesto al que este viendo
            //Mathf me ayuda a mandar los valores, en este caso volviendolos opuestos
                body.velocity=new Vector2(-Mathf.Sign(transform.localScale.x) * 3,6);
            }
            wallJumpCooldown=0;
            
        }

    }
    //Si esta en el piso puede saltar
    private bool isGrounded()
    {
        RaycastHit2D raycastHit=Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    //Si esta contra la pared puede hacer salto de pared
    private bool onWall()
    {
        RaycastHit2D raycastHit=Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    //Para realizar un ataque tiene que estar en el piso y sin estar en una pared
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
