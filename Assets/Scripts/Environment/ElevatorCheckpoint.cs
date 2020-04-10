using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Checkpoint for main elevator.If you fall off the top you can take the elevator up
public class ElevatorCheckpoint : MonoBehaviour
{
    public bool touched;
    public Animator anim;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touched = true;
            anim.SetTrigger("AgilityComplete");
        }


    }
}
