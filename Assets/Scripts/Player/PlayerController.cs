using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Basement Trigger
    //public GameObject healthSystem;

    // Animator
    private Animator anim;

    // Player Controller
    private float horizontalInput;
    public float moveSpeed;
    public float sprintSpeed;
    public float jumpForce;
    private bool isFacingRight = true;
    private float currentSpeed;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isSprinting = false;

    public LayerMask groundLayer;
    public Transform groundCheck;

    public Inventory inventory;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Player Movement
        horizontalInput = Input.GetAxis("Horizontal");
        currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(moveDirection.x * currentSpeed, rb.velocity.y);
        Flip();

        // Set animator parameters for walking and running
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(horizontalInput) > 0)
        {
            isSprinting = true;
            anim.SetBool("isRunning", true);
        }
        else
        {
            isSprinting = false;
            anim.SetBool("isRunning", false);
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

    //// Basement Trigger
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Basement")
    //    {
    //        healthSystem.SetActive(true);
    //    }
    //}

    //// Basement Exit Trigger
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "BasementExit")
    //    {
    //        healthSystem.SetActive(false);
    //    }
    //}
}
