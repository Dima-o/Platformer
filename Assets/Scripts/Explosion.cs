using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject disappearingBarrel;
    [SerializeField] private SpriteRenderer arrow;
    [SerializeField] private PolygonCollider2D arrowCollid;

    DeleteObjects deleteObjects;

    private float timeExplosion;
    private bool activeExplosion;

    private bool activeDelete;

    void Start()
    {
        deleteObjects = GetComponent<DeleteObjects>();
        explosion.SetActive(false);
        timeExplosion = 5;
        activeExplosion = false;
        activeDelete = false;
    }

    void Update()
    {
        if (activeExplosion)
        {
            ActiveTimeExplosion();
        }

        if (activeDelete)
        {
            deleteObjects.Delete();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            arrow.enabled = false;
            arrowCollid.enabled = false;
            disappearingBarrel.SetActive(false);
            explosion.SetActive(true);

            activeExplosion = true;
        }
    }

    private void ActiveTimeExplosion()
    {
        timeExplosion -= Time.deltaTime;

        if (timeExplosion <= 0)
        {
            explosion.SetActive(false);
            activeExplosion = false;
            activeDelete = true;
        }

    }
}
