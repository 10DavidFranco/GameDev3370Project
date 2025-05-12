using System.Collections;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_player : MonoBehaviour
{

    [Header("Dashing")]
    public float dashspeed = 20f;
    public float dashduration = 0.5f;
    public float dashcooldown = 0.1f;
    private Vector2 dashingdir;
    bool isDashing;
    bool canDash = true;
    TrailRenderer trailRenderer;
    public int health = 3;


    float horizontalInput;
    public float moveSpeed = 25f;
    bool isFacingRight = false;
    public float jumpPower = 30f;
    bool isGrounded = false;


    Rigidbody2D rb;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        flipchecker();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        checkDeath();
    }

    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocityY);

        animator.SetFloat("xVelocity", math.abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        dashingdir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dashingdir == Vector2.zero)
        {
            if (!isFacingRight)
            {
                dashingdir = new Vector2(transform.localScale.x, 0f);
            }
            else
            {
                dashingdir = new Vector2(-transform.localScale.x, 0f);
            }
        }
        rb.linearVelocity = dashingdir.normalized * dashspeed;
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashduration);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashcooldown);
        canDash = true;


    }



    private void flipchecker()
    {
        if (horizontalInput > 0 && isFacingRight)
        {
            FlipSprite();
        }
        else if (horizontalInput < 0 && !isFacingRight)
        {
            FlipSprite();
        }
    }
    void FlipSprite()
    {

        isFacingRight = !isFacingRight;
        transform.Rotate(1f, 180f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Player has been hit!!!");
            
            health--;
            Debug.Log(health);
            checkDeath();
        }
    }

    private void checkDeath()
    {
        if(health <= 0)
        {
            Debug.Log("You Lost...");
            SceneManager.LoadScene("Game_Over");
        }
    }

   


}

