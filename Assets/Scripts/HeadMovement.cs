using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    private float horizontal;
    private float inputSpeed;

    public float speed;
    public float jumpingPower;
    public bool facingRight;

    public float maxSpeed;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //per tick
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
 

        if(horizontal == 0)
        {
            if (rb.angularVelocity != 0)
            {
                rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0, 0.003f);

            }
            inputSpeed = 0;
        }

    }

    //per frame
    private void FixedUpdate()
    {
        //thimo ik heb velocity veranderd naar addforce zodat het draaien er beter uitziet
        //zorg ervoor dat je sneller kan stoppen en starten want de snelheid is best fucked up
        inputSpeed = Mathf.Lerp(inputSpeed, horizontal * speed, 0.03f);
        //rb.velocity = new Vector2((inputSpeed * 250) * Time.deltaTime, rb.velocity.y);
        rb.AddForce(new Vector2((inputSpeed * 250) * Time.deltaTime, rb.velocity.y), ForceMode2D.Force);
        //if not rolling in idle 
        if(horizontal != 0)
        {
            MaxSpeed();
        }

    }

    private void MaxSpeed()
    {
        if(rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

