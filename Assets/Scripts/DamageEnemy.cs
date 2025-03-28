using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DamageEnemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamde(damage);
            Destroy(gameObject);

            //if (collision.gameObject.GetComponent<Health>().IsAlive == false)
            //{
            //    //dataCounter.CounterData();
            //}
        } 
    }
}
