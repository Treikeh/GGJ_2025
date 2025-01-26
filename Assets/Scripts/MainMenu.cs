using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text micText;

    void Start()
    {
        string currentMic = Microphone.devices[Globals.micIndex];
        micText.text = currentMic;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }


    public void ChangeMic()
    {
        // Change mic
        int micAmount = Microphone.devices.Length;
        if (Globals.micIndex == (micAmount - 1))
        {
            Globals.micIndex = 0;
        }
        else
        {
            Globals.micIndex += 1;
        }
        // Update mic text
        string currentMic = Microphone.devices[Globals.micIndex];
        micText.text = currentMic;
        Debug.Log(Globals.micIndex);
    }
}
