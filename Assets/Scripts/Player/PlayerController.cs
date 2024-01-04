using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isSprinting = false;

    public LayerMask groundLayer;
    public Transform groundCheck;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * currentSpeed, rb.velocity.y);

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
