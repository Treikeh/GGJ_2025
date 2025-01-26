using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject nextLevelScreen;

    public string nextLevelName;

    private void OnEnable() {
        Globals.playerWon += OnPlayerWon;
        Globals.playerFailed += OnPlayerFailed;
    }

    private void OnDisable() {
        Globals.playerWon -= OnPlayerWon;
        Globals.playerFailed -= OnPlayerFailed;
    }


    private void OnPlayerWon()
    {
        nextLevelScreen.SetActive(true);
    }

    private void OnPlayerFailed()
    {
        gameOverScreen.SetActive(true);
    }


    public void OnNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }


    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
