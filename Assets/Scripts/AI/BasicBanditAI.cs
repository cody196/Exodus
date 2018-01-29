using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBanditAI : MonoBehaviour {


    public float health = 100f;
    public float hunger = 100f;
    public float thirst = 100f;

    public float hungerSpeedMultiplier = 2.5f;
    public float thirstSpeedMultiplier = 2.5f;
    public float healthSpeedMultiplier = 5f;

    public void start()
    {

    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Update()
    {
        checkHealth();
    }

    /// <summary>
    /// Checks the health of the bandit,
    /// sets bandit's properties appropriately
    /// </summary>
    public void checkHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Bandit died");

            // set bandit ai to false, if bandit is found
            //if (transform.Find("BanditAI") != null)
            //{
                transform.Find("BanditAI").gameObject.SetActive(false);
            //}
            //else
            //{
            //    Debug.Log("Cannot find bandit");
            //}
            // set bandit kinematic to false
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
