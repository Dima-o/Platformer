using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private float jumpOffset;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundCollliderTrancform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float maxAcceleration;     
    [SerializeField] private float minAirAcceleration;  
    
    private SpriteRenderer spriteRenderer;

    private AnimationsSetup animationsSetup;
    private Health health;
    private Rigidbody2D rb;

    private float desiredVelocity;
    private float verticalSpeed;

    public bool LookDirection => spriteRenderer.flipX;
    private bool activeeMove;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationsSetup = GetComponent<AnimationsSetup>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        activeeMove = true;
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundCollliderTrancform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask); 
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (health.IsAlive && activeeMove)
        {
            verticalSpeed = rb.velocity.y;

            if (!isGrounded)
            {
                animationsSetup.AnimJump(verticalSpeed, isGrounded);

            } 
            else
            {
                animationsSetup.OffAnimJump(true);
            }

            if (isJumpButtonPressed)
            {
                Jump();
            }

            if (Mathf.Abs(direction) > 0.01F)
            {
                HorizontalMovement(direction);  
            }

            if (Mathf.Abs(direction) == 0)
            {
                animationsSetup.AnimOffRun();
            }
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        if (isGrounded)
        {
            animationsSetup.AnimOnRun();
            
        }
        else
        {
            animationsSetup.AnimOffRun();
            
        }

        desiredVelocity = curve.Evaluate(direction);

        var acceleration = isGrounded ? maxAcceleration : minAirAcceleration;
        var velocity = rb.velocity;
        var maxSpeedChange = acceleration * Time.fixedDeltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity, maxSpeedChange);
        rb.velocity = velocity;

        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void FreezingMove(bool active)
    {
        activeeMove = active;
    }
}
