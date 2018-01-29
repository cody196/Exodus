using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour {

    public int health = 1000;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
