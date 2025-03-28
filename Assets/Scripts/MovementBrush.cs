using UnityEngine;

public class MovementBrush : MonoBehaviour
{
    [SerializeField] private float initialTimer;

    private HingeJoint2D hingeJoint2D;
    private float timer;

    private void Start()
    {
        hingeJoint2D = GetComponent<HingeJoint2D>();
        UpdatingData();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer >= 0)
        {
            hingeJoint2D.useMotor = true;
        }
        else if (timer <= -1)
        {
            UpdatingData();
        }
    }

    private void UpdatingData()
    {
        timer = initialTimer;
        hingeJoint2D.useMotor = false;
    }
}
