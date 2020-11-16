using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer pSprite;

    public float pSpeed;
    

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
    }
}
