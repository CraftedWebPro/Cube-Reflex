using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class ScoreUpdate : MonoBehaviour
{
    public PlayerMovement movement;
     // Reference to CollderLogic for accessing movement state
    public Transform player; // Reference to the player transform
    public TMP_Text scoreUpdateText; // Use TMP_Text for TextMeshPro

    private bool isScoreUpdating = true; // Flag to control score updating

    void Update()
    {
        // Update the TMP text with the player's z position formatted as an integer
        if (isScoreUpdating)
        {
            scoreUpdateText.text = player.position.z.ToString("0");
            StopScore();
        }
    }

    // Method to stop updating the score
    public void StopScore()
    {
        // Check if the player's movement is disabled
        if (!movement.enabled || player.position.y < -1) // Correct way to check if movement is disabled
        {
            isScoreUpdating = false; // Set the flag to false to stop updates
            Debug.Log("Score updating stopped.");
        }
    }
}
