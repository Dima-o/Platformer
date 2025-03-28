using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    [SerializeField] private BoxCollider2D collider2D;

    private void Start()
    {
        collider2D.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            collider2D.enabled = false;
        }
    }
}
