using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTP : MonoBehaviour
{
    public GameObject destination;

    public void OnTriggerEnter(Collider col)
    {
        col.gameObject.transform.position = destination.transform.position;
        Debug.Log("I'm so triggered");
    }
}
