using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodItemList", menuName = "FoodItemList/FoodItemList", order = 99)]
public class FoodItemGameObjSO : ScriptableObject
{
   public List<FoodItemGameObj> FoodItemList;

    public GameObject GetGameObject(FoodItem foodItem)
    {
        foreach (var item in FoodItemList)
        {
            if(item.foodItem == foodItem)
            {
                return item.ItemObject;
            }
        }

        return null;
    }
}






