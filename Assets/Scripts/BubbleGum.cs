using UnityEngine;

public class BubbleGum : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Bubble gum");
            Globals.bubbleGumPickedUp?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
