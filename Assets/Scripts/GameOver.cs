using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// The hud

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject nextLevelScreen;
    public GameObject dialogeText;

    public string nextLevelName;

    private void OnEnable() {
        Globals.playerWon += OnPlayerWon;
        Globals.playerFailed += OnPlayerFailed;
        Globals.bubbleHit += OnBubbleHit;
    }

    private void OnDisable() {
        Globals.playerWon -= OnPlayerWon;
        Globals.playerFailed -= OnPlayerFailed;
        Globals.bubbleHit -= OnBubbleHit;

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

    private void OnBubbleHit()
    {
        dialogeText.SetActive(true);
        Invoke(nameof(HideDialogeText), 3f);
    }

    private void HideDialogeText()
    {
        dialogeText.SetActive(false);
    }
}
