using UnityEngine;

// Credits: Valem tutorials, https://www.youtube.com/watch?v=dzD0qP8viLw

public class MicDetection : MonoBehaviour
{
    public int device = 0;
    private int samlpeWindow = 64;
    private AudioClip micClip;


    void Start()
    {
        MicToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MicToAudioClip()
    {
        // Mic to AudioClip
        string micName = Microphone.devices[device];
        Debug.Log(micName);
        micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }


    public float GetLoudnessFromMic()
    {
        return GetLoadnessFromAudioClip(Microphone.GetPosition(Microphone.devices[device]), micClip);
    }


    public float GetLoadnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - samlpeWindow;

        if (startPosition < 0)
        {
            Debug.Log("Start position < 0");
            return 0;
        }

        float[] waveData = new float [samlpeWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0f;

        for (int i = 0; i < samlpeWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        Debug.Log("Total loudness " + totalLoudness);
        return totalLoudness / samlpeWindow;
    }
}
