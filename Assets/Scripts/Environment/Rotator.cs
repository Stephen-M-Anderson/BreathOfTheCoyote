using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script rotates the trophies
public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
