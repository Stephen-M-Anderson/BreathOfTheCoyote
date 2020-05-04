using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CMFreelookControlOverride : MonoBehaviour
{
    public Joystick HeyFuckYouJoystick;

    public CinemachineFreeLook freeLookCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        freeLookCam.m_XAxis.Value += HeyFuckYouJoystick.Horizontal;
        freeLookCam.m_YAxis.Value += HeyFuckYouJoystick.Vertical;
        Debug.Log(freeLookCam.m_XAxis.Value);
        Debug.Log(freeLookCam.m_YAxis.Value);

    }
}
