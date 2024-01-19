using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed = 5;
    public float lucnhay = 5;
    private bool isGround;
    private float dichuyen;
    private Animator aim;
    public Transform _isGround;
    public LayerMask san;
    private bool dou_Jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(_isGround.position, 0.2f, san);
        dichuyen = Input.GetAxis("Horizontal");
        if ((isGround && !Input.GetKey(KeyCode.UpArrow)))
        {
            dou_Jump = false;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (dou_Jump || isGround)
            {
                if (dou_Jump && !isGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, lucnhay + 2f);
                    dou_Jump = !dou_Jump;

                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, lucnhay);
                    dou_Jump = !dou_Jump;

                }

            }

        }
        if (dichuyen > 0 || dichuyen < 0 && isGround)
        {
            aim.SetBool("Run", true);
        }
        else
        {
            aim.SetBool("Run", false);
        }
        aim.SetBool("Jump", !isGround);
        flip(dichuyen);
      

    }


    void flip(float dichuyen)
    {
        if (dichuyen < 0)
        {
            transform.localScale = new Vector3(-0.5842444f, 0.5189486f, 1);
            rb.velocity = new Vector2(dichuyen * speed, rb.velocity.y);

        }
        if (dichuyen > 0)
        {
            transform.localScale = new Vector3(0.5842444f, 0.5189486f, 1);
            rb.velocity = new Vector2(dichuyen * speed, rb.velocity.y);
        }
    }

}
