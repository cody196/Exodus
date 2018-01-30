using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject deathCanvas;

    public Vector3 spawnPoint = Vector3.zero;
    public float health = 100f;

    public float hunger = 100f;
    public float thirst = 100f;

    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;

    public float hungerSpeedMultiplier = 0.25f;
    public float thirstSpeedMultiplier = 0.50f;
    public float healthSpeedMultiplier = 0.25f;

    private bool isDying = false;

    private void start()
    {
        deathCanvas.SetActive(false);
    }

    // Used for applying functions every tick
    private void Update()
    {
        CheckDeath();

        if(hunger > 0)
        {
            hunger -= Time.deltaTime * hungerSpeedMultiplier; // Subtract hunger if it is greater than 0
        }

        if (thirst > 0)
        {
            thirst -= Time.deltaTime * thirstSpeedMultiplier; // Subtract thirst if it is greater than 0
        }

        if(hunger <= 0 || thirst <= 0)
        {
            isDying = true;
        }
        else
        {
            isDying = false;
        }

        // Reduce health if the player is dying
        if(isDying == true)
        {
            health -= Time.deltaTime * healthSpeedMultiplier;
        }

        if(hunger > 100)
        {
            hunger = 100f;
        }

        if(thirst > 100)
        {
            thirst = 100f;
        }

        // Health, hunger, and thirst divided by the max value
        healthBar.fillAmount = health / 100;
        hungerBar.fillAmount = hunger / 100;
        thirstBar.fillAmount = thirst / 100;
    }

    // Check if player has died
    private void CheckDeath()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    // Die function
    private void Die()
    {
        deathCanvas.SetActive(true);
    }

    // Respawn function and resets all statistic values
    public void Respawn()
    {
        health = 100;
        hunger = 100;
        thirst = 100;
        deathCanvas.SetActive(false);
        transform.position = spawnPoint;
    }

    public void AddHunger(float amount)
    {
        hunger += amount;
    }

    public void AddThirst(float amount)
    {
        thirst += amount;
    }

    public void AttackPlayer(float amount)
    {
        health -= amount;
    }
}
