using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform doorTransform;
    [SerializeField] private Transform counterTransform;
    
    public CustomerMover Spawn()
    {
        var customer = Instantiate(customerPrefab, startTransform);

        var customerMover = customer.GetComponent<CustomerMover>();
        customerMover.Init(startTransform, doorTransform, counterTransform);
        
        return customerMover;
    }
}
