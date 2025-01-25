using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 200f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private ScaleFromMic _bubbleScale;

    private float _horizontalInput = 0f;
    private bool isGrounded = false;
    private Rigidbody2D _rBody;


    void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = _horizontalInput * _moveSpeed * Time.deltaTime;
        _rBody.gravityScale = _bubbleScale.desiredScale;

        if (Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        _rBody.linearVelocity = new Vector2(horizontalMovement, _rBody.linearVelocity.y);
    }


    private void OnJump()
    {
        if (isGrounded == true)
        {
            _rBody.linearVelocity = new Vector3(_rBody.linearVelocityX, _jumpForce);
        }
    }
}
