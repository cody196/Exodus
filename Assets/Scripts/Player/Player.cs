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

    private void start()
    {
        deathCanvas.SetActive(false);
    }

    private void Update()
    {
        CheckDeath();

        if(hunger > 0)
        {
            hunger -= Time.deltaTime * hungerSpeedMultiplier;
        }

        if (thirst > 0)
        {
            thirst -= Time.deltaTime * thirstSpeedMultiplier;
        }

        healthBar.fillAmount = health / 100;
        hungerBar.fillAmount = hunger / 100;
        thirstBar.fillAmount = thirst / 100;
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        deathCanvas.SetActive(true);
    }

    public void Respawn()
    {
        health = 100;
        hunger = 100;
        thirst = 100;
        deathCanvas.SetActive(false);
        transform.position = spawnPoint;
    }
}
