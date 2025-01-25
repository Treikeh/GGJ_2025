using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 200f;
    private float _horizontalInput = 0f;
    private Rigidbody2D _rBody;


    void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = _horizontalInput * moveSpeed * Time.deltaTime;
        _rBody.linearVelocity = new Vector2(horizontalMovement, _rBody.linearVelocityY);
    }
}
