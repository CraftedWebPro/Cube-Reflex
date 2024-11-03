using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public Transform player; // Reference to the player transform

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.transform == player) 
        {
            gameManager.TriggerGameWon(); // Call the Game Won method
            Debug.Log("Player reached the End Point!");
        }
    }
}
