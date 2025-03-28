using UnityEngine;

public class SettingFan : MonoBehaviour
{
    [SerializeField] private bool activeFan;
    [SerializeField] private GameObject particles;

    private AnimationsSetup animationsSetup;
    
    private void Start()
    {
        animationsSetup = GetComponent<AnimationsSetup>();
        particles.SetActive(false);
    }

    private void Update()
    {
        if (activeFan)
        {
            animationsSetup.AnimFanOnOff(true);
            particles.SetActive(true);
        }
    }

    public void ActiveFan(bool active)
    {        
        activeFan = active;
    }
}
