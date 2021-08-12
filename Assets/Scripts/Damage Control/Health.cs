/*
Nombre del desarrollador: Emilio Ceballos Castro
Asignatura: Programación Orientada a Objetos
Fuente en la que se basa el scripts: Canal de Youtube Pandemonium games
Descripción general: Script creado para manejar y controlar la vida del personaje 
al igual que sus animaciones pertinentes de daño y muerte
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField]private float iFrameDuration;
    [SerializeField]private int numberOffFlashes;
    private SpriteRenderer spriteRend;

    private void Awake() 
    {
        currentHealth = startingHealth;   
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //Se usa un StartCorutine para que se pause la lectura hasta que se cumpla la condicion 
            //en este caso la de invulnerabilidad
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
            anim.SetTrigger("Death");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;
            
            }
        }
    }

    public void addHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        //Esta variable se esta usando para que el personaje tenga un para de segundo de invulnerabilidad
        //al chocar con un enemigo, esto usando Layers y una representacion visual
        Physics2D.IgnoreLayerCollision(8,9,true);
        //Duracion de la invulnarabilidad
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOffFlashes) * 2);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOffFlashes) * 2);
        }
        Physics2D.IgnoreLayerCollision(8,9,false);
    }
}
