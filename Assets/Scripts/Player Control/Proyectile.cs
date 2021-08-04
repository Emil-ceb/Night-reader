using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D bCollide;
    private float lifeTime;
    
    private void Awake() 
    {
        anim = GetComponent<Animator>();
        bCollide=GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if(hit)return;
        float movementSpeed = speed*Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0,0);

        lifeTime += Time.deltaTime;
        if(lifeTime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        hit = true;
        bCollide.enabled = false;
        anim.SetTrigger("Explode");
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        bCollide.enabled = true;

        float localScaleX=transform.localScale.x;

        if(Mathf.Sign(localScaleX) !=_direction)
        {
            localScaleX= -localScaleX;
        }
        transform.localScale = new Vector3 (localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
