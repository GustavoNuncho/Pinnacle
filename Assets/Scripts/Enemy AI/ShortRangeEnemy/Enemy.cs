using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

     public StateMachine  stateMachine =>  GetComponent<StateMachine>();
      public ShortRangeEnemy _ShortRangeEnemy => GetComponent<ShortRangeEnemy>();



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
            currentHealth -= damage;
            Debug.Log(currentHealth);
            _ShortRangeEnemy.stateMachine.enabled = false;

        //Play hurt animation
    }

    public void Die()
    {
        
        _ShortRangeEnemy.enabled = false;

        Destroy(this.gameObject, 2.0f);
    }

}
