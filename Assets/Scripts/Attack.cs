using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private float radiusAttack;
    [SerializeField] private float damage;

    private AnimationsSetup animationsSetup;
    private Health health;

    private PlayerMovement playerMovement;

    private float attackPointPositionX;
    private float attackPointPositionY;

    private float initialAttackPointPositionX;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animationsSetup = GetComponent<AnimationsSetup>();
        health = GetComponent<Health>();

        attackPointPositionY = attackPoint.localPosition.y;
        initialAttackPointPositionX = attackPoint.localPosition.x;
    }

    public void Hit()
    {
        if (health.IsAlive)
        {

            animationsSetup.AnimAtack("Atack");

            if (playerMovement.LookDirection)
            {
                attackPointPositionX = -initialAttackPointPositionX;
            }
            else
            {
                attackPointPositionX = initialAttackPointPositionX;
            } 
        } 
    }

    private void DealingDamage()
    {
        attackPoint.localPosition = new Vector2(attackPointPositionX, attackPointPositionY);

        Collider2D[] collider = Physics2D.OverlapCircleAll(attackPoint.position, radiusAttack, attackLayerMask);

        if (collider.Length != 0)
        {
            for (int i = 0; i < collider.Length; i++)
            {
                collider[i].GetComponent<Health>().TakeDamde(damage);
            }
        }
    }
}
