using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMWPaltform : MonoBehaviour
{
    private GameObject target = null;
    private Vector3 offset;
    void Start()
    {
        target = null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            offset = target.transform.position - transform.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
}
