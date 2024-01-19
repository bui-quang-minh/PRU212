using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded = false;
    public bool ck;

    private Rigidbody2D rb;
    public Transform groundCheck;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {   
        // Player movement
         float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");     
         Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
         rb.velocity = movement;
        // Player jumping
        if (Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded)
        {
            rb.velocity += new Vector2(rb.velocity.x,jumpForce);
            isGrounded = false;
        }
        anim.SetBool("ground", isGrounded);
    }

    // Ground check
    private bool IsWall(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, LayerMask.GetMask("Ground"));
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }  
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
