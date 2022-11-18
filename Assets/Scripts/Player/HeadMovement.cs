using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using static PlayerManager;

public class HeadMovement
{
    private float horizontal;
    private float inputSpeed;
    private bool facingRight;

    private float speed;
    private float jumpingPower;
    private float maxSpeed;

    private Rigidbody2D rb;
    private Transform groundCheck;
    private LayerMask groundLayer;

    public HeadMovement(float speed,float maxSpeed, float jumpingPower, PlayerManager pm)
    {
        this.maxSpeed = maxSpeed;
        this.speed = speed;
        this.jumpingPower = jumpingPower;
        pm.frameUpdate += FixedUpdate;

        rb = pm.GetComponent<Rigidbody2D>();
        groundCheck = pm.transform;
        groundLayer = LayerMask.GetMask("Ground");

    }

    //per frame
    // // \\ // \\ // \\
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            Debug.Log("jump");
        }
            

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 0)
        {
            if (rb.angularVelocity != 0)
                rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0, 0.003f);

            inputSpeed = 0;
        }

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
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private void MaxSpeed()
    {
        if(rb.velocity.x > maxSpeed || rb.velocity.x < -maxSpeed)
        {
            Debug.Log(rb.velocity.x);
            rb.velocity = new Vector2(horizontal * maxSpeed - (horizontal * 2), rb.velocity.y);
        }
            
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // \\ // \\ // \\ //
}

