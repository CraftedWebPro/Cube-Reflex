using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GameStart");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
