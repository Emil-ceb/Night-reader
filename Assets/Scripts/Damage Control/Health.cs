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
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

    private void Awake() 
    {
        currentHealth = startingHealth;   
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
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
}
