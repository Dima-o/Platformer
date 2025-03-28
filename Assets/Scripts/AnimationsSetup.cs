using UnityEngine;

public class AnimationsSetup : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimAtack(string atack)
    {
        animator.SetTrigger(atack);
    }

    public void AnimJump(float derictionSpeed, bool isGrounded)
    {
        animator.SetFloat("direction", derictionSpeed);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void OffAnimJump(bool isGraunded)
    {
        animator.SetBool("isGrounded", isGraunded);
    }

    public void AnimDeath(string anim)
    {
        animator.SetBool("activeRun", false);
        animator.SetBool(anim, true);     
    }

    public void AnimOnRun()
    {
        animator.SetBool("activeRun", true);
    }

    public void AnimOffRun()
    {
        animator.SetBool("activeRun", false);
    }

    public void AnimEnemy(float indicator)
    {
        animator.SetFloat("Velocity", indicator);
    }

    public void AnimFanOnOff(bool active)
    {
        animator.SetBool("active", active);
    }

    public void AnimPlatformsBridge(bool open)
    {
        animator.SetBool("openBridge", open);
    }

    public void AnimBlackStripe(bool active)
    {
        animator.SetBool("activatorStripe", active);
    }
}
