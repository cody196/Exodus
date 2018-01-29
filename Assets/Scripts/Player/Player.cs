using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject deathCanvas;

    public Vector3 spawnPoint = Vector3.zero;
    public float health = 100f;

    private void start()
    {
        deathCanvas.SetActive(false);
    }

    private void Update()
    {
        CheckDeath();
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
        deathCanvas.SetActive(false);
        transform.position = spawnPoint;
    }
}
