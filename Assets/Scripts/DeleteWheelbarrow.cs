using UnityEngine;

public class DeleteWheelbarrow : MonoBehaviour
{
    [SerializeField] GameObject wheelbarrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Delete"))
        {
            wheelbarrow.SetActive(false);
        }
    }
}
