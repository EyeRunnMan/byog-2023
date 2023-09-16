using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableFoodUI : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI text;
    
    public FoodItem FoodItem;

    private void Start()
    {
        text.text = FoodItem.ToString();
    }

    public void ToggleUI(bool toggle)
    {
        canvas.SetActive(toggle);
    }
}
