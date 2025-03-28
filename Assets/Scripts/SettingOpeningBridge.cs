using UnityEngine;

public class SettingOpeningBridge : MonoBehaviour
{
    [SerializeField] private AnimationsSetup animationsSetupPlatform1;
    [SerializeField] private AnimationsSetup animationsSetupPlatform2;

    private bool openClosedBridge;

    private void Start()
    {
        openClosedBridge = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            openClosedBridge = !openClosedBridge;
            MenegmentBridge();
        }
    }

    private void MenegmentBridge()
    {
        if (openClosedBridge)
        {
            OpenClosedBridge(true);
        }
        else
        {
            OpenClosedBridge(false);
        }
    }

    private void OpenClosedBridge(bool open)
    {
        animationsSetupPlatform1.AnimPlatformsBridge(open);
        animationsSetupPlatform2.AnimPlatformsBridge(open);
    }
}
