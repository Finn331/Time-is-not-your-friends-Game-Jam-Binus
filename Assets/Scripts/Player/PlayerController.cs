using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float moveSpeed;
    public float sprintSpeed;
    public float jumpForce;
    private bool isFacingRight = true;

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
        horizontalInput = Input.GetAxis("Horizontal");
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * currentSpeed, rb.velocity.y);
        Flip();

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
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
