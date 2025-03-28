using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SpriteRenderer spriteRendererArrow;
    [SerializeField] private float fireSpeed;

    private GameObject currentBullet;
    private Rigidbody2D currentBulletVelocity;

    private PlayerMovement playerMovement;
    private AnimationsSetup animationsSetup;
    private Health health;


    private float firePointPositionX;
    private float firePointPositionY;

    private float initialFirePointPositionX;

    private bool activeAttack;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animationsSetup = GetComponent<AnimationsSetup>();
        health = GetComponent<Health>();

        firePointPositionY = firePoint.localPosition.y;
        initialFirePointPositionX = firePoint.localPosition.x;

        activeAttack = true;
    }

    public void Shoot()
    {
        if (activeAttack)
        {
            if (playerMovement.LookDirection)
            {
                firePointPositionX = -initialFirePointPositionX;
                spriteRendererArrow.flipX = true;
            }
            else
            {
                firePointPositionX = initialFirePointPositionX;
                spriteRendererArrow.flipX = false;
            }

            firePoint.localPosition = new Vector2(firePointPositionX, firePointPositionY);

            if (health.IsAlive)
            {
                animationsSetup.AnimAtack("Atack");
                activeAttack = false;

                currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
                currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

                if (playerMovement.LookDirection)
                {
                    DirectionShootSpeed(-fireSpeed);
                }
                else
                {
                    DirectionShootSpeed(fireSpeed);
                }
            }
        }     
    }

    public void ActivatorAttack()
    {
        activeAttack = true;
    }

    private void DirectionShootSpeed(float fireSpeed)
    {      
        currentBulletVelocity.velocity = new Vector2(fireSpeed, currentBulletVelocity.velocity.y);   
    }
}
