using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float rotationDuration = 0.2f;
    
    [SerializeField] private Transform doorTransform;
    [SerializeField] private Transform counterTransform;

    public Action OnReached;

    private void Start()
    {
         StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        // Move to door.
        yield return MoveToLocation(doorTransform);

        // Look towards counter.
        transform.LookAt(counterTransform);
        
        // Wait.
        yield return StartCoroutine(LookAtCounter());
        
        // Move to counter.
        yield return MoveToLocation(counterTransform);
        
        OnReached?.Invoke();
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

    private IEnumerator LookAtCounter()
    {
        // Calculate the direction vector from this object to the target.
        Vector3 direction = counterTransform.position - transform.position;

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
