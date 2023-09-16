using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private CustomerSpawner customerSpawner;
    
    private bool isAwaitingCustomer;
    
    private void Update()
    {
        if (isAwaitingCustomer) return;

        var customerMover = customerSpawner.Spawn();
        customerMover.OnExitReached += () => isAwaitingCustomer = false;

        isAwaitingCustomer = true;
    }
}
