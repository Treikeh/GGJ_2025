using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{
    [SerializeField] private MicDetection detector;
    [SerializeField] private float loudnessSensibility = 10f;
    [SerializeField] private float threshold = 0.1f;

    public float scaleLerpSpeed = 1f;
    public float increaseSpeed = 1f;
    public float reductionSpeed = 0.1f;
    public float maxScale = 3f;

    private float desiredScale = 1f;
    private Vector2 maxSize;
    


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
