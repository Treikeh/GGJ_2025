using UnityEngine;
using UnityEngine.Events;

public class KillFloor : MonoBehaviour
{
    public UnityEvent entered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Globals.playerFailed?.Invoke();
        }
    }
}
