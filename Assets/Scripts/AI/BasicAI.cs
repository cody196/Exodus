using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {

    public int health = 100;

    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;

    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Finds the component for the AI
    }

    private void Update()
    {
        if(isChasing == true)
        {
            agent.SetDestination(playerTransform.position); // Set Destination to the player
        }
    }

    private void OnTriggerEnter(Collider target) // When we enter the collider
    {
        if(target.tag == "Player") // Checks if the target is tagged as "Player"
        {
            playerTransform = target.transform; // Referance the players transform
            isChasing = true;
        }
        if(health <= 0)
        {
            Destroy(gameObject); // Destroy GameObject
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Reduce health from health variable
        Debug.Log("Zombie took damage");
    }

}
