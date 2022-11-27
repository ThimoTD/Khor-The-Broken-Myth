using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.Profiling;
using UnityEngine;
using static PlayerManager;

public class HeadMovement : IPartMovement
{
    private float horizontal;
    private float inputSpeed;
    private bool facingRight;

    private float speed;

    private Rigidbody2D rb;
    private Transform groundCheck;
    private LayerMask groundLayer;

    // // \\ // \\ // \\
    public HeadMovement(float speed, PlayerManager pm)
    {
        this.speed = speed;
        pm.frameUpdate += FixedUpdate;

        rb = pm.GetComponent<Rigidbody2D>();
        groundCheck = pm.transform;
        groundLayer = LayerMask.GetMask("Ground");

    }
    // \\ // \\ // \\ //

    //per frame
    // // \\ // \\ // \\
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 0)
        {
            if (rb.angularVelocity != 0)
                rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0, 0.003f);

            inputSpeed = 0;
        }

        inputSpeed = Mathf.Lerp(inputSpeed, horizontal * speed, 0.03f);
        float fi = inputSpeed; // input force
        float F = Mathf.Clamp(((fi / rb.mass) * (Time.fixedDeltaTime * 300)) - rb.velocity.x, -Mathf.Infinity, Mathf.Infinity); // Force

        rb.AddForce(new Vector2(F, rb.velocity.y), ForceMode2D.Force);
        Vt();
    }
    // \\ // \\ // \\ //


    private bool Vt()
    {
        if(rb.velocity.y < -250)
        {
            rb.velocity = new Vector2(rb.velocity.x, -250);
            return true;
        }
        return false;
    }
    // // \\ // \\ // \\
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    // \\ // \\ // \\ //

    public void UpdateConfig()
    {
        throw new System.NotImplementedException();
    }
}

