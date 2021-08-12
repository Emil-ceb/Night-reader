/*
Nombre del desarrollador: Emilio Ceballos Castro
Asignatura: Programación Orientada a Objetos
Fuente en la que se basa el scripts: Canal de Youtube Pandemonium games
Descripción general: Este script es usado para enemigos y trampas basicas que no requieren de mucho 
pensamiento ni movimiento, es decir unicamente se mueven de una direccion a otra
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingLeft;
    private float leftSide;
    private float rightSide;

    private void Awake() 
    {
        //Scripts basicos para registrar cuando ve a la derecha o izquierda
        leftSide = transform.position.x - movementDistance;
        rightSide = transform.position.x + movementDistance;
    }

    private void Update() 
    {
        if (movingLeft)
        {
            if(transform.position.x > leftSide)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale=new Vector3(-1,1,1);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if(transform.position.x < rightSide)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.localScale=Vector3.one;
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
