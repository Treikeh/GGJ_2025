using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{

    public AudioSource source;
    public Vector2 minScale;
    public Vector2 maxScale;
    public MicDetection detector;

    public float loudnessSensibility = 100f;
    public float threshold = 0.1f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMic() * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0f;
        }

        transform.localScale = Vector2.Lerp(minScale, maxScale, loudness);
    }
}
