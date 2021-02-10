using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;

    public bool facingRight = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

// Character animation and movement
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveInput.x == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        rb.velocity = moveInput * speed * Time.deltaTime;

        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }

// Moving the character
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + rb.velocity * Time.fixedDeltaTime);
    }

// Flips the character
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
