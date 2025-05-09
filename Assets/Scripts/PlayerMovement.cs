using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myrb;
    Vector2 moveInput;
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;

    bool isGrounded;

    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move horizontally
        myrb.linearVelocity = new Vector2(moveInput.x * moveSpeed, myrb.linearVelocity.y);

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }


    void FixedUpdate()
    {
        // Update grounded state during physics update
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Move horizontally
        myrb.linearVelocity = new Vector2(moveInput.x * moveSpeed, myrb.linearVelocity.y);
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        // Do a fresh ground check right before jumping
        bool checkGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (value.isPressed && checkGrounded)
        {
            myrb.linearVelocity = new Vector2(myrb.linearVelocity.x, jumpForce);
        }
    }

}
