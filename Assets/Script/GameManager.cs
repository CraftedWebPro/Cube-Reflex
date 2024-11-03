using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    public GameObject gameOverCanvas; // Reference to the Game Over canvas
    public GameObject gameWonCanvas; // Reference to the Game Won canvas
    private bool isGameOver = false; // Flag to check if the game is over
    private bool isGameWon = false; // Flag to check if the game is won


    public void GameMenuReset()
    {
        SceneManager.LoadSceneAsync("Game Menu");
    }

    void Start()
    {
        gameOverCanvas.SetActive(false);
        gameWonCanvas.SetActive(false); // Ensure game won canvas is inactive at start
    }

    void Update()
    {
        // Check for game over condition
        if (!isGameOver && player.position.y < -1) // Replace -1 with a constant if needed
        {
            TriggerGameOver();
        }

        // Handle restart input
        if (isGameOver && Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void TriggerGameWon()
    {
        isGameWon = true;
        gameWonCanvas.SetActive(true);
        Debug.Log("Game Won!");
    }

    public void RestartGame()
    {
        isGameOver = false;
        isGameWon = false; // Reset the game won state
        gameOverCanvas.SetActive(false);
        gameWonCanvas.SetActive(false); // Hide game won canvas on restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.position = new Vector3(0, 1, 0); // Adjust as needed
    }

    public bool IsGameOver()
    {
        return isGameOver; // Return the current game over state
    }

    public bool IsGameWon()
    {
        return isGameWon; // Return the current game won state
    }

    

}
