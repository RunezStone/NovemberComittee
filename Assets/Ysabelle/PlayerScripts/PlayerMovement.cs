using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool canJump = true;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = movement * moveSpeed;

        // Creates a circle to see if the player is on the groundLayer
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(canJump && Input.GetButtonDown("Space"))
        {
            Debug.Log("Player is Jumping");
        }

    }
}
