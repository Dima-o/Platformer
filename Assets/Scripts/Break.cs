using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] private FixedJoint2D breakingPart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            breakingPart.breakForce = 0;
            Destroy(gameObject);
        }       
    }
}
