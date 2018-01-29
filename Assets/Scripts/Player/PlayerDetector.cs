using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

    private Transform playerDetectorTransform;

    private AdvancedZombieAI advancedZombieAI;

    private void Start()
    {
        advancedZombieAI = GetComponentInParent<AdvancedZombieAI>(); // Finds the AdvancedZombieAI script
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "player")
        {
            playerDetectorTransform = target.GetComponent<Transform>();

            if(advancedZombieAI.playerTransform == null)
            {
                advancedZombieAI.playerTransform = playerDetectorTransform;
            }
        }
    }
}
