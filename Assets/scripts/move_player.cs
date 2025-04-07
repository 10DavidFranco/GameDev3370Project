using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class move_player : MonoBehaviour
{

    float horizontalInput;
    float moveSpeed = 25f;
    bool isFacingRight = false;
    float jumpPower = 30f;
    bool isGrounded = false;
   

    Rigidbody2D rb;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping",!isGrounded);
        
        }

    
     
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocityY );
      
        animator.SetFloat("xVelocity", math.abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        { 
            isFacingRight =!isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
                }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded=true;
        animator.SetBool("isJumping", !isGrounded);
    }



}

