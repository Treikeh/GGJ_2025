using UnityEngine;

public class RocketTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Rocket");
            Globals.enteredRocket?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
