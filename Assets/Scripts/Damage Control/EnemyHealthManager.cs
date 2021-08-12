using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public Animator anim;
    void Start() 
    {
        anim=GetComponent<Animator>();
        enemyCurrentHealth = enemyMaxHealth;        
    }

    void update()
    {
        if(enemyCurrentHealth <= 0)
        {
            //anim.SetTrigger("Death");
            //GetComponent<EnemySimple>().enabled=false;
            gameObject.SetActive(false);
            Debug.Log("Death");
        }
    }

    public void HurtEnemy(int _damageEn)
    {
        enemyCurrentHealth -= _damageEn;
    }

    public void SetMaxHealht()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
}
