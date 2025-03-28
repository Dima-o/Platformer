using UnityEngine;

public class MessageDeath : MonoBehaviour
{
    [SerializeField] private GameObject Death;
    [SerializeField] private float timerAppearanceMessage;

    private Health health;
    private bool activeTimer;
    private float timer;

    private void Start()
    {
        Death.SetActive(false);
        health = GetComponent<Health>();
        activeTimer = true;
        timer = timerAppearanceMessage;
    }

    private void Update()
    {
        if (health.IsAlive == false)
        {
            TimerBeforeMessage();
        }

        if (health.IsAlive == false && timer <= 0)
        {
            Death.SetActive(true);
            Time.timeScale = 0;
            activeTimer = false;
            timer = timerAppearanceMessage;
        }
    }

    public void TimerBeforeMessage()
    {
        if (activeTimer)
        {
            timer -= Time.deltaTime;
        }
    }
}
