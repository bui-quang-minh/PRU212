using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Move upwards on "W" key press
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity += new Vector2(rb.velocity.x,jumpForce);
            isGrounded = false;
        }
        anim.SetBool("ground", isGrounded);
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ground"){
             isGrounded = true;
        }
    }
}