using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{
    public float scaleLerpSpeed = 5f;
    public float increaseSpeed = 1f;
    public float reductionSpeed = 0.1f;
    public float maxScale = 3f;
    public MicDetection detector;

    public float loudnessSensibility = 10f;
    public float threshold = 0.1f;

    private Vector2 maxSize;
    private float desiredScale = 1f;
    


    void Update()
    {
        float loudness = detector.GetLoudnessFromMic() * loudnessSensibility;
        Debug.Log("Detected loudness" + loudness);

        if (loudness < threshold)
        {
            loudness = 0f;
            desiredScale -= reductionSpeed;
        }

        desiredScale += loudness * increaseSpeed;
        desiredScale = Mathf.Clamp(desiredScale, 1f, maxScale);

        maxSize = new Vector2(1f, 1f) * desiredScale;

        transform.localScale = Vector2.Lerp(transform.localScale, maxSize, scaleLerpSpeed);
    }
}
