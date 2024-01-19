using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;

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
    }

    private void Update()
    {   
        // Player movement
         float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
        ck = IsWall();
         if(!IsWall()){
         Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
         rb.velocity = movement;
         }
        // Player jumping
        if (Input.GetKeyDown(KeyCode.UpArrow)&& isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
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
