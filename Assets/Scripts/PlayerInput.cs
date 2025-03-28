using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Attack attack;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        attack = GetComponent<Attack>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GloballStringVars.horizontalAxis);
        bool isJumpButtonPressed = Input.GetButtonDown(GloballStringVars.jump);

        if (Input.GetButtonDown(GloballStringVars.fire1))
        {
            //shooter.Shoot();
            attack.Hit();
        }

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
