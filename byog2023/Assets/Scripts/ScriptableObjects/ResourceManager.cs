using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public FoodItemGameObjSO FoodItemSO;

    private void Awake()
    {
        Instance = this;
    }
}
