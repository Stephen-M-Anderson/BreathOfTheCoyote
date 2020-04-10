using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Incomplete respawn mechanic testing
public class BoundTP : MonoBehaviour
{
    public GameObject Player;
    public Transform RespawnPoint;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("TP time");

            Player.transform.position = RespawnPoint.transform.position;
        }
    }
}
