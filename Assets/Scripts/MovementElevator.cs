using UnityEngine;

public class MovementElevator : MonoBehaviour
{
    [SerializeField] private SliderJoint2D activeMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            activeMovement.useMotor = true;
        }
    }
}
