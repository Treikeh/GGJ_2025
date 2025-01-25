using UnityEngine;

public class MicDetection : MonoBehaviour
{
    private int samlpeWindow = 64;
    private AudioClip micClip;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MicToAudioClip()
    {
        // Mic to AudioClip
        string micName = Microphone.devices[0];
        micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }


    public float GetLoudnessFromMic()
    {
        return GetLoadnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), micClip);
    }


    public float GetLoadnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - samlpeWindow;

        if (startPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float [samlpeWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0f;

        for (int i = 0; i < samlpeWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }


        return totalLoudness / samlpeWindow;
    }
}
