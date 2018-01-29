using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public float interactRange = 5f;
    public Camera FPSCamera;

    private FoodItem foodItem;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hitInfo, interactRange))
            {
                if (hitInfo.collider.tag == "FoodItem")
                {
                    foodItem = hitInfo.collider.GetComponent<FoodItem>();

                    if (foodItem.hungerType == FoodItem.HungerType.Food)
                    {
                        player.AddHunger(foodItem.addAmount);
                        foodItem.DestroyObject();
                    }
                    else if (foodItem.hungerType == FoodItem.HungerType.Water)
                    {
                        player.AddThirst(foodItem.addAmount);
                        foodItem.DestroyObject();
                    }
                }
            }
        }
    }
   
}
