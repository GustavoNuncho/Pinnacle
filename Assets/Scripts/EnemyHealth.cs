using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    private int damage = 10;

    public Slider healthSlider;

    GameState game;

    public void Start()
    {
        UpdateHealthSlider();

        game = GetComponent<GameState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "PlayerSword")
            {
                TakeDamage();

                UpdateHealthSlider();
            }
        }

    public void TakeDamage()
    {
        health -= damage;

        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health == 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);

        game.EnemyDied();
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = health;
    }
}
