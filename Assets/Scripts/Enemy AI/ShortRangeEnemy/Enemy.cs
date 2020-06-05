using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public    Slider healthSlider;
    public int maxHealth = 100;
    public int currentHealth;

     public StateMachine  stateMachine =>  GetComponent<StateMachine>();
      public ShortRangeEnemy _ShortRangeEnemy => GetComponent<ShortRangeEnemy>();



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        UpdateHealthSlider();
    
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
     public void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }

}
