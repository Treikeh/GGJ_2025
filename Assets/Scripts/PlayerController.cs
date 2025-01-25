using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 200f;
    [SerializeField] private float _jumpForce = 5f;

    public float gravityScale = 1f;

    private float _horizontalInput = 0f;
    private Rigidbody2D _rBody;
    private MicDetection _micDetector;


    void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _micDetector = GetComponent<MicDetection>();
    }


    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = _horizontalInput * _moveSpeed * Time.deltaTime;

        // Ground check

        _rBody.linearVelocity = new Vector2(horizontalMovement, _rBody.linearVelocity.y);
    }


    private void OnJump()
    {
        _rBody.linearVelocity = new Vector3(_rBody.linearVelocityX, _jumpForce);
    }
}
