using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class SparkDirection : MonoBehaviour
{
    public static readonly string DirectionBall = "Direction";
    public VisualEffect myEffect;
    private Vector3 pointer;
   
    // Start is called before the first frame update
    void Start()
    {
        pointer = -(gameObject.transform.forward);
        myEffect.SetVector3(DirectionBall, pointer);
        Destroy(gameObject, 2.5f);
        Debug.Log(pointer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
