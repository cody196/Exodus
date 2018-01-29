using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedZombieAI : MonoBehaviour {

    public int health = 100;
    public float viewRange = 25f;
    public float attackRange = 5f;

    public bool isChasing = false;

    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Finds the component for the AI
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hitInfo;

        CheckHealth();

        if(Physics.Raycast(ray, out hitInfo, viewRange))
        {
            if(hitInfo.collider.tag == "Player")
            {
                if (isChasing == false)
                {
                    playerTransform = hitInfo.collider.GetComponent<Transform>();
                    isChasing = true;
                }
            }
        }

        if(Physics.Raycast(ray, out hitInfo, attackRange))
        {

        }

        Debug.DrawRay(ray.origin, ray.direction * viewRange, Color.red);


        if (isChasing == true)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Zombie took damage");
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
