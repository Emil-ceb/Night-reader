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
    private float cooldownTimer = Mathf.Infinity;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
        pMove = GetComponent<PlayerMovement>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Z) && cooldownTimer > attackCooldown && pMove.canAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
        
        //un object pooling se usa para multiples objetos 
        energy[FindEnergy()].transform.position = energyPoint.position;
        energy[FindEnergy()].GetComponent<Proyectile>().SetDirection(Mathf.Sign(transform.localScale.x));
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
