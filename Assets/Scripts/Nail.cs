using UnityEngine;

public class Nail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bubble")
        {
            Debug.Log("Nail");
            Globals.bubbleHit?.Invoke();
        }
    }
}
