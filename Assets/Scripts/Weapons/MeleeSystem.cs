using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour {

    public int minDamage = 25;
    public int maxDamage = 50;
    public float weaponRange = 3.5f;

    public Camera FPSCamera;

    private TreeHealth treeHealth;
    private BasicAI basicAI;

    private void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.green);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(ray, out hitInfo, weaponRange))
            {
                if(hitInfo.collider.tag == "Tree") // Checks if the tree is hit and performs function for the tree
                {
                    treeHealth = hitInfo.collider.GetComponentInParent<TreeHealth>();
                    AttackTree();
                }

                else if (hitInfo.collider.tag == "Zombie") // Checks if the tagged Zombie is hit
                {
                    basicAI = hitInfo.collider.GetComponent<BasicAI>(); // Finds the script component called "BasicAI"
                    AttackEnemy();
                }
            }
        }
    }

    private void AttackTree()
    {
        Debug.Log("Attack Tree");

        int damage = Random.Range(minDamage, maxDamage);
        treeHealth.health -= damage;
    }

    private void AttackEnemy()
    {
        int damage = Random.Range(minDamage, maxDamage);
        basicAI.TakeDamage(damage);
    }
}
