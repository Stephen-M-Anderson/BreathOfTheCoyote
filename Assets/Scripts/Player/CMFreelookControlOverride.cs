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
        freeLookCam.m_XAxis.Value += HeyFuckYouJoystick.Horizontal*3;
        freeLookCam.m_YAxis.Value += -HeyFuckYouJoystick.Vertical/50;
      //  Debug.Log("X Axis" + freeLookCam.m_XAxis.Value);
    //    Debug.Log("Y axis" + freeLookCam.m_YAxis.Value);

    }
}
