using UnityEngine;
using UnityEngine.Events;

public class BubbleHitBox : MonoBehaviour
{
    public UnityEvent bubblePopped;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bubblePopped.Invoke();
    }
}
