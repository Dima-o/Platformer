using UnityEngine;

public class FunctionalityForTiles : MonoBehaviour
{
    [SerializeField] private AreaEffector2D effectorFan;
    [SerializeField] private SliderJoint2D slidingDoor;

    [SerializeField] private SettingFan settingFan1;
    [SerializeField] private SettingFan settingFan2;

    private CameraSwitch cameraSwitch;

    private void Start()
    {
        cameraSwitch = GetComponent<CameraSwitch>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            cameraSwitch.CameraSwitcher(1);

            slidingDoor.useMotor = true;
            effectorFan.enabled = true;

            settingFan1.ActiveFan(true);
            settingFan2.ActiveFan(true);
        }
    }
}
