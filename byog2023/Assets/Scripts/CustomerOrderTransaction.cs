using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerOrderTransaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public UnityEvent OnTransactionComplete;

    [ContextMenu("Complete Transaction")]
    public void CompleteTransaction()
    {
        OnTransactionComplete.Invoke();
    }

}
