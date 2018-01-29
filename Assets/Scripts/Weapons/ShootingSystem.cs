using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {

    public float weaponRange = 100f;
    public Camera FPSCamera;

    public int minDamage = 25;
    public int maxDamage = 75;

    private AdvancedZombieAI zombieAI;

    private void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0)) // Shoot at target when we mouse click
        {
            if (Physics.Raycast(ray, out hitInfo, weaponRange)) // Checks for collision of the ray
            {
                if(hitInfo.collider.tag == "Zombie")
                {
                    zombieAI = hitInfo.collider.GetComponent<AdvancedZombieAI>();
                    zombieAI.TakeDamage(Damage());
                }
            }
        }
    }

    private int Damage()
    {
        return Random.Range(minDamage, maxDamage);
    }

}
