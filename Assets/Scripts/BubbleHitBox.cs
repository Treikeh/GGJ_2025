using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class BubbleHitBox : MonoBehaviour
{
    public UnityEvent bubblePopped;

    public bool destroy = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bubblePopped.Invoke();
        if (destroy)
        {
            other.gameObject.SetActive(false);
        }
    }
}
