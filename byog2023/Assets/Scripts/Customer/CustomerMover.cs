using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CustomerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float rotationDuration = 0.2f;
    
    [SerializeField] private UnityEvent OnCounterReach;
    
    private Transform startTransform;
    private Transform doorTransform;
    private Transform counterTransform;
    
    public Action OnExitReached;

    private void Start()
    {
        transform.SetPositionAndRotation(startTransform.position, startTransform.rotation);
        
        StartCoroutine(MoveToCounter());
    }

    public void Init(in Transform startTransform, Transform doorTransform, Transform counterTransform)
    {
        this.startTransform = startTransform;
        this.doorTransform = doorTransform;
        this.counterTransform = counterTransform;
    }

    private IEnumerator MoveToCounter()
    {
        // Move to door.
        yield return MoveToLocation(doorTransform);

        // Look towards counter.
        transform.LookAt(counterTransform);
        
        // Wait.
        yield return StartCoroutine(Look(counterTransform));
        
        // Move to counter.
        yield return MoveToLocation(counterTransform);
        
        OnCounterReach?.Invoke();
    }

    public void MoveToExitWrapper()
    {
        StartCoroutine(MoveToExit());
    }
    
    private IEnumerator MoveToExit()
    {
        // Move to door.
        yield return MoveToLocation(doorTransform);

        // Look towards exit.
        transform.LookAt(counterTransform);
        
        // Wait.
        yield return StartCoroutine(Look(startTransform));
        
        // Move to exit.
        yield return MoveToLocation(startTransform);
        
        OnExitReached?.Invoke();
    }

    private IEnumerator MoveToLocation(Transform destination)
    {
        var distance = Vector3.Distance(transform.position, destination.position);
        while (distance > 0.5f)
        {
            // Calculate the direction to move towards the target.
            var direction = (destination.position - transform.position).normalized;
            direction.y = 0f;
            
            // Move the object towards the target at the specified speed.
            transform.position += direction * (moveSpeed * Time.deltaTime);
            
            // Update destination.
            distance = Vector3.Distance(transform.position, destination.position);

            yield return null;
        }
    }

    private IEnumerator Look(Transform target)
    {
        // Calculate the direction vector from this object to the target.
        Vector3 direction = target.position - transform.position;

        // Calculate the rotation needed to look at the target.
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Record the starting rotation.
        Quaternion startRotation = transform.rotation;

        float elapsedTime = 0.0f;

        while (elapsedTime < rotationDuration)
        {
            // Interpolate between the starting rotation and the target rotation.
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotationDuration);

            // Update the elapsed time.
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame.
        }

        // Ensure the object is precisely facing the target.
        transform.rotation = targetRotation;
    }
}
