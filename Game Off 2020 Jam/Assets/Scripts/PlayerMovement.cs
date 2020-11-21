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

    void Start()
    {
        
    }

    void Update()
    {
        moveHor = Input.GetAxisRaw("Horizontal");
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

    }
}
