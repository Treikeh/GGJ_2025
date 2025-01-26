using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 200f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private ScaleFromMic _bubbleScale;
    [SerializeField] private bool gumUnlocked = false;
    [SerializeField] private GameObject bubbleSprite;
    private float _horizontalInput = 0f;
    private bool isGrounded = false;
    private Rigidbody2D _rBody;


    private void OnEnable() {
        Globals.playerWon += OnPlayerFailed;
        Globals.playerFailed += OnPlayerFailed;
        Globals.bubbleHit += OnBubbleHit;
        Globals.bubbleGumPickedUp += OnBubbleGumPickedUp;
    }

    private void OnDisable() {
        Globals.playerWon -= OnPlayerFailed;
        Globals.playerFailed -= OnPlayerFailed;
        Globals.bubbleHit -= OnBubbleHit;
        Globals.bubbleGumPickedUp -= OnBubbleGumPickedUp;
    }

    private void OnPlayerFailed()
    {
        _rBody.linearVelocity = Vector2.zero;
        enabled = false;
    }


    void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        if (gumUnlocked)
        {
            bubbleSprite.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = _horizontalInput * _moveSpeed * Time.deltaTime;

        if (gumUnlocked)
        {
            _rBody.gravityScale = map(_bubbleScale.desiredScale, 1f, _bubbleScale.maxScale, 1f, 0.5f);
        }

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

    public void OnBubbleHit()
    {
        bubbleSprite.SetActive(false);
    }


    public void OnBubbleGumPickedUp()
    {
        gumUnlocked = true;
        bubbleSprite.SetActive(true);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
