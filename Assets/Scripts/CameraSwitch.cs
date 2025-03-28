using Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera mainVirtualCamera;
    [SerializeField] private CinemachineVirtualCamera secondaryVirtualCamera;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private AnimationsSetup animationsSetup1;
    [SerializeField] private AnimationsSetup animationsSetup2;

    [SerializeField] private float reverseSwitchingTime;

    private float timer;

    private int switcher;
    private int priorityMainCamera = 2;
    private int prioritySecondaryCamera = 1;

    private void Start()
    {     
        InitialData();
    }

    private void Update()
    {
        if (switcher == priorityMainCamera)
        {
            mainVirtualCamera.Priority = priorityMainCamera;
        }
        else if (switcher == prioritySecondaryCamera)
        {
            ActiveStrips(true);

            playerMovement.FreezingMove(false);
            mainVirtualCamera.Priority = prioritySecondaryCamera;
            secondaryVirtualCamera.Priority = priorityMainCamera;

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                InitialData();
                ActiveStrips(false);
            }
        }
    }

    private void InitialData()
    {
        playerMovement.FreezingMove(true);

        mainVirtualCamera.Priority = priorityMainCamera;
        secondaryVirtualCamera.Priority = prioritySecondaryCamera;

        switcher = priorityMainCamera;
        timer = reverseSwitchingTime;     
    }

    private void ActiveStrips(bool active)
    {
        animationsSetup1.AnimBlackStripe(active);
        animationsSetup2.AnimBlackStripe(active);
    }

    public void CameraSwitcher(int index)
    {
        switcher = index;
    }
}
