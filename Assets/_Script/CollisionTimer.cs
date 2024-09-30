using UnityEngine;
using DG;
using DG.Tweening;

public class CollisionTimer : MonoBehaviour
{
    private bool isColliding = false;
    private float collisionTime = 0f;
    private float requiredCollisionTime = 1f;  // Time required to trigger the action (in seconds)

    // Called when the collision starts
    private void OnCollisionEnter(Collision collision)
    {
        // Check if we are colliding with a specific object by tag or name
        if (collision.gameObject.CompareTag("Ball"))
        {
            isColliding = true;
            collisionTime = 0f;  // Reset the timer
        }
    }

    // Called while the collision is happening
    private void OnCollisionStay(Collision collision)
    {
        if (isColliding)
        {
            // Increment the timer while the collision is active
            collisionTime += Time.deltaTime;

            // Check if the collision lasted for more than 1 second
            if (collisionTime >= requiredCollisionTime)
            {
                Debug.Log("Collision lasted more than 1 second!");
                // Perform your action here
                // ...
                DOTween.Restart("1SecMove");
                // Optionally, reset the timer after the action is triggered
                collisionTime = 0f;
                isColliding = false;  // Resetting collision tracking
            }
        }
    }

    // Called when the collision ends
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            isColliding = false;
            collisionTime = 0f;  // Reset the timer
        }
    }
}
