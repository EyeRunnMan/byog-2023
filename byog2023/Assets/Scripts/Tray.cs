using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public List<Transform> positionsInTray;
    List<GameObject> gameobjetsintray;
    List<FoodItem> foodItems;
    int occupancyCount = 0;

    private void Awake()
    {
        gameobjetsintray = new();
        foodItems = new();
        occupancyCount = 0;
    }

    public void AddToTray(GameObject itemIncoming,FoodItem foodItem)
    {
        if (itemIncoming != null)
        {
            itemIncoming.transform.parent = transform;
            itemIncoming.transform.localPosition = positionsInTray[occupancyCount].localPosition;
            occupancyCount++;
        }
    }

    public List<FoodItem> GetCurrentListOfoodItems()
    {
        return new(foodItems);
    }

}
