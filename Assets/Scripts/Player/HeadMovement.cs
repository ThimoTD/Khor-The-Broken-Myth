using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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

        inputSpeed = Mathf.Lerp(inputSpeed, horizontal * speed, 0.03f);
        float F = inputSpeed;
        float v = Mathf.Clamp(((F / rb.mass) * (Time.fixedDeltaTime * 300)) - rb.velocity.x, -Mathf.Infinity, Mathf.Infinity);

        Debug.Log(v);
        rb.AddForce(new Vector2(v, rb.velocity.y), ForceMode2D.Force);
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

