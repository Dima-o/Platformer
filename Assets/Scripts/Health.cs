using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image HelthImage;
    [SerializeField] private Text healthText;
    [SerializeField] private DataCounter dataCounter;

    [SerializeField] private float maxHealth;
    [SerializeField] private float timerDelete;
    [SerializeField] private BoxCollider2D BoxColliderTrigger;

    private AnimationsSetup animationsSetup;
    private CapsuleCollider2D capsuleCollider;
    private Rigidbody2D rb;
    
    private float currentHealth;

    public bool IsAlive => currentHealth > 0;

    private void Awake()
    {
        animationsSetup = GetComponent<AnimationsSetup>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthText.text = maxHealth.ToString();
    }

    public void TakeDamde(float damage)
    {
        currentHealth -= damage;
        HelthImage.fillAmount = currentHealth / 100;

        if (currentHealth >= 0)
        {
            healthText.text = currentHealth.ToString();
        }

        if (IsAlive == false) 
        {          
            animationsSetup.AnimDeath("activeDeath");
            //capsuleCollider.enabled = false;

            if (gameObject.name != "Knight")
            {
                capsuleCollider.enabled = false;
                dataCounter.CounterDataEnemy();
                BoxColliderTrigger.enabled = false;
                rb.simulated = false;
            }

            Destroy(gameObject, timerDelete);
        }
    }
}
