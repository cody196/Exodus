using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedZombieAI : MonoBehaviour
{

    public int health = 100;
    public float viewRange = 25f;
    public float attackRange = 5f;

    public float minimumDamage = 25f;
    public float maximumDamage = 40f;

    public float thinkTimer = 5f;
    private float thinkTimerMin = 5f;
    private float thinkTimerMax = 10f;
    private UnityEngine.AI.NavMeshAgent agent;

    public Transform playerTransform;
    public Transform playerTransformDist;

    public float randomUnitCircleRadius = 25f;
    public float eyeHeight;
    public bool isChasing = false;
    public bool isAttacking = false;
    public float distanceToAttack = 1.8f;
    public float attackTime = 1f;
    private float attackTimeStart;
    public float distanceToPlayer;

    private Player player;

    public Ray ray;
    public RaycastHit hitInfo;


    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Finds the component for the AI
        thinkTimer = Random.Range(thinkTimerMin, thinkTimerMax);
        attackTimeStart = attackTime;
        playerTransformDist = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransformDist.position); // Get player's distance

        Vector3 eyePosition = new Vector3(transform.position.x, transform.position.y + eyeHeight, transform.position.z);

        ray = new Ray(eyePosition, transform.forward);

        CheckHealth();

        // Attack Thinking
        if (distanceToPlayer <= distanceToAttack && isChasing == true) // Check the distance between the player and the attack range
        {
            isAttacking = true;
        }

        if(isAttacking == true)
        {
            attackTime -= Time.deltaTime;
            isChasing = false;
            agent.SetDestination(transform.position);
        }

        if (attackTime <= 0)
        {
            Attack();
            attackTime = attackTimeStart;
            isAttacking = false;
            CheckForPlayer();
        }



        thinkTimer -= Time.deltaTime;

        if (thinkTimer <= 0)
        {
            Think();
            thinkTimer = Random.Range(thinkTimerMin, thinkTimerMax);
        }

        CheckForPlayer();

        Debug.DrawRay(ray.origin, ray.direction * viewRange, Color.red);


        if (isChasing == true && isAttacking == false)
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

    private void Attack()
    {
        float damage = Random.Range(minimumDamage, maximumDamage);
        // Attack Functions
        if(distanceToPlayer <= distanceToAttack)
        {
            if (Physics.Raycast(ray, out hitInfo, attackRange))
            {
                if(hitInfo.collider.tag == "Player")
                {
                    player.AttackPlayer(damage);
                }
            }
        }
    }

    private void CheckForPlayer()
    {
        if (Physics.Raycast(ray, out hitInfo, viewRange))
        {
            if (hitInfo.collider.tag == "Player")
            {
                if (isChasing == false && isAttacking == false)
                {
                    isChasing = true;

                    if (playerTransform == null) // If player transform is empty
                    {
                        playerTransform = hitInfo.collider.GetComponent<Transform>();
                    }
                }
            }
        }
    }
}
