using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour
{
    protected Vector2 direction=Vector2.zero;

    protected bool directionForward;
    
    [SerializeField]
    protected float velocidadMovimiento;
    Animator animPlayer;


    void Awake() 
    {
        animPlayer=GetComponent<Animator>();
    }

    protected virtual void ControlPersonaje()
    {
        this.transform.Translate(direction.normalized*velocidadMovimiento*Time.deltaTime);
    }
}
