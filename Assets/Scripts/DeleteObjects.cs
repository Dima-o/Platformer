using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask mask;

    public void Delete()
    {
        Collider2D[] collidewr = Physics2D.OverlapCircleAll(transform.position, radius, mask);

        foreach (Collider2D col in collidewr)
        {
            Destroy(col.gameObject);
        }
    }
}
