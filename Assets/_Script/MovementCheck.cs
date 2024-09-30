using UnityEngine;
using DG;

public class MovementCheck : MonoBehaviour
{
    [SerializeField] private float timeToCheck = 0.5f; // Time to check for movement
    private Vector3 lastPosition;
    private bool isMoving;
    private float movingTime; // The time the object has been moving

    private void Start()
    {
        lastPosition = transform.position; // Initial position
        isMoving = false;
        movingTime = 0f;
    }

    private void Update()
    {
        CheckIfMoving();
    }

    private void CheckIfMoving()
    {
        // Check if the position has changed
        if (transform.position != lastPosition)
        {
            isMoving = true; // Object is moving
            movingTime += Time.deltaTime; // Increase the moving time
        }
        else
        {
            isMoving = false; // Object stopped moving
            movingTime = 0f; // Reset moving time
        }

        // If the object has been moving for the specified time
        if (isMoving && movingTime >= timeToCheck)
        {
            Debug.Log("The object has been moving for " + timeToCheck + " seconds.");
            // You can trigger other events or actions here
        }

        lastPosition = transform.position; // Update the last position
    }
}
