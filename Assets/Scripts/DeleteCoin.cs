using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteCoin : MonoBehaviour
{
    [SerializeField] DataCounter dataCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            dataCounter.CounterDataCoins();
            Destroy(gameObject);
        }
    }
}
