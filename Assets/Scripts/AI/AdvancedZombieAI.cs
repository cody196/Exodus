using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedZombieAI : MonoBehaviour
{

    public int health = 100;
    public float viewRange = 25f;
    public float attackRange = 5f;

    public float thinkTimer = 5f;
    private float thinkTimerMin = 5f;
    private float thinkTimerMax = 10f;

    public float randomUnitCircleRadius = 10f;

    public float eyeHeight;

    public bool isChasing = false;

    public Transform playerTransform;

    private UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Finds the component for the AI

        thinkTimer = Random.Range(thinkTimerMin, thinkTimerMax);
    }

    private void Update()
    {
        Vector3 eyePosition = new Vector3(transform.position.x, transform.position.y + eyeHeight, transform.position.z);

        Ray ray = new Ray(eyePosition, Vector3.forward);
        RaycastHit hitInfo;

        CheckHealth();

        thinkTimer -= Time.deltaTime;

        if (thinkTimer <= 0)
        {
            Think();
            thinkTimer = Random.Range(thinkTimerMin, thinkTimerMax);
        }

        if (Physics.Raycast(ray, out hitInfo, viewRange))
        {
            if (hitInfo.collider.tag == "Player")
            {
                if (isChasing == false)
                {
                    isChasing = true;

                    if (playerTransform == null) // If player transform is empty
                    {
                        playerTransform = hitInfo.collider.GetComponent<Transform>();
                    }
                }
            }
        }

        if (Physics.Raycast(ray, out hitInfo, attackRange))
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

        if (playerTransform != null)
        {
            isChasing = true;
        }

        Debug.Log("Zombie took damage");
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Think()
    {
        if (isChasing == false)
        {
            Vector3 newPos = transform.position + new Vector3(Random.insideUnitCircle.x * randomUnitCircleRadius, transform.position.y, Random.insideUnitCircle.y * randomUnitCircleRadius);
            agent.SetDestination(newPos);
        }
    }
}
