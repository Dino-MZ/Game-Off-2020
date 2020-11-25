using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer pSprite;

    public float pSpeed;
    public float fHorizontalDamping = 0.5f;

    private float moveHor;

    public string GroundTag = "Ground";
    public Transform GroundCheck;
    public LayerMask JumpableLayers;
    public float checkRadius;
    public bool onGround;
    public bool isJumping;
    public float JumpPower = 10;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool jump;
    private bool jumpUp;
    private bool jumpDown;

    void Start()
    {
        
    }

    void Update()
    {
        moveHor = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        jumpUp = Input.GetKeyUp(KeyCode.Space);
        jumpDown = Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        // Move Right
        if(moveHor > 0)
        {
            rb.AddForce(transform.right * pSpeed);
            pSprite.flipX = false;
        }

        // Move Left
        if (moveHor < 0)
        {
            rb.AddForce(transform.right * -pSpeed);
            pSprite.flipX = true;
        }

        // speeding up
        float fHorizontalVelocity = rb.velocity.x;
        fHorizontalVelocity += Input.GetAxisRaw("Horizontal");
        fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDamping, Time.deltaTime * 10f);
        rb.velocity = new Vector2(fHorizontalVelocity, rb.velocity.y);

        // ========================================== Jumping ======================================= \\

        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, JumpableLayers);

        if (onGround && jumpDown)
        {
            Vector2 JumpY = Vector2.up * JumpPower * 10f * Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, JumpY.y);
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if (jump && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                //rigid.velocity = Vector2.up * JumpPower * 10f * Time.deltaTime;
                Vector2 JumpY = Vector2.up * JumpPower * 10f * Time.deltaTime;
                rb.velocity = new Vector2(rb.velocity.x, JumpY.y);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (jumpUp)
        {
            isJumping = false;
        }

    }
}
