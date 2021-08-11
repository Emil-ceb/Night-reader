/*
Nombre del desarrollador: Emilio Ceballos Castro
Asignatura: Programación Orientada a Objetos
Fuente en la que se basa el scripts: Canal de Youtube Pandemonium games
Descripción general: Script usado para manejar los ataques y sus animaciones del personaje
al igual que almacenar los proyectiles en caso de que el personaje los use
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform energyPoint;
    [SerializeField] private GameObject[] energy;
    private Animator anim;
    private PlayerMovement pMove;
    //El mathf.infinity es usado para generar un numero infinito para que cooldownTimer
    //siempre sea mayor que attckCooldown
    private float cooldownTimer = Mathf.Infinity;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
        pMove = GetComponent<PlayerMovement>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.C) && cooldownTimer > attackCooldown && pMove.canAttack())
        {
            attackEnergy();
        }
        cooldownTimer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Z))
        {
            attackHeavy();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            attackLight();
        }
    }

    private void attackEnergy()
    {
        anim.SetTrigger("Energy");
        cooldownTimer = 0;
        
        //un object pooling se usa para multiples objetos reciclandolos sin tiempo muerto entre usos
        //energy[FindEnergy()].transform.position = energyPoint.position;
        //energy[FindEnergy()].GetComponent<Proyectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void attackHeavy()
    {
        anim.SetTrigger("AttackHeavy");
    }
    private void attackLight()
    {
        anim.SetTrigger("AttackLight");
    }

    private int FindEnergy()
    {
        for (int i = 0; i < energy.Length; i++)
        {
            if(!energy[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
