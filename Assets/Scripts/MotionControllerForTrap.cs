using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControllerForTrap : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.simulated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.simulated = true;
    }
}
