using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class CollderLogic : MonoBehaviour
{
    public PlayerMovement movement;
    public GameManager gameManager;
    public Transform player;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            movement.enabled = false; // Disable player movement
                 
            Debug.Log("Collision detected with an obstacle. Player movement stopped.");

          
            
            // Trigger game over after a delay
            StartCoroutine(TriggerGameOverAfterDelay(1f)); // Delay of 1 second
        }
    }

    private IEnumerator TriggerGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.TriggerGameOver();
    }
}