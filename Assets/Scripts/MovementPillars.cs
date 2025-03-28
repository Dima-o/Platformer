using System;
using UnityEngine;

public class MovementPillars : MonoBehaviour
{
    [SerializeField] private Rigidbody2D pillar;

    private SliderJoint2D activeMovement;
    private JointMotor2D motor;

    private bool back;
    private float speed = 0.8f;

    private void Start()
    {
        activeMovement = GetComponent<SliderJoint2D>();
        activeMovement.useMotor = true;

        back = true;
    }

    private void Update()
    {
        if (back)
        {
            motor = activeMovement.motor;
            motor.motorSpeed = speed;
            activeMovement.motor = motor;
        }
        else
        {
            motor = activeMovement.motor;
            motor.motorSpeed = -speed;
            activeMovement.motor = motor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            if (motor.motorSpeed > 0)
            {
                back = false;
            }
            else if (motor.motorSpeed < 0)
            {
                back = true;
            }
        } 
    }
}
