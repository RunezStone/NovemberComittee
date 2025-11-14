using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool canJump = true;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Horizontal movement
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveX, 0f);
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Ground check
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player is Jumping");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
