using UnityEngine;

public class Cloudsmoving : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Speed at which the object moves to the left.")]
    public float speed = 5f;

    void Update()
    {
        // Move the object to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
