using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;
    
    void Awake()
    {
        instance = this;
    
    }
    #endregion

    public GameObject player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
         Camera cam = (Camera)FindObjectOfType(typeof(Camera));
        if (cam)
            Debug.Log("Camera object found: " + cam.name);
        else
            Debug.Log("No Camera object could be found");
    }
  void Update()
  {
      player= GameObject.FindWithTag("Player");    
      
      
  }
}
