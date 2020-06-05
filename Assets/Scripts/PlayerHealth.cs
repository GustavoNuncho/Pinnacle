using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;

    public PlayerHealth player;

    GameState game;

    public int health = 100;

    private int damage = 10;

    void Start()
    {
        UpdateHealthSlider();

        game = GetComponent<GameState>();
    }

    private void OnColliderEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy")
        {
            TakeDamage();

            CheckHealth();

            UpdateHealthSlider();

        }
    }

    public int GetPlayerHealth()
    {
        return health;
    }

    public void TakeDamage()
    {
        health -= damage;
    }

    public void CheckHealth()
    {
        if (health == 0)
            Die();

    }

    public void UpdateHealthSlider()
    {
        healthSlider.value = health;
    }

    private void Die()
    {
        game.PlayerDied();

        Destroy(gameObject);
    }
}
