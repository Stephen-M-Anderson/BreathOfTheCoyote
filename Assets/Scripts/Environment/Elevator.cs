using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject[] points;
    public int current = 0;
    public float speed;
    public ElevatorCheckpoint Chp;
    public bool colliding;
    public Vector3 Platmove;
    public float dist;
    public bool movingtime;
    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector3.Distance(transform.position, points[current].transform.position);
        if (current !=0 && transform.position != points[current].transform.position)
        {
            Platmove = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
            transform.position = Platmove;
            movingtime = true;
        }
        if (current == 0 && transform.position != points[current].transform.position)
        {
            Platmove = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
            transform.position = Platmove;
            movingtime = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("palyer touched me");
            colliding = true;
            if (Chp.touched)
            {
                current = 2;
            }
            else
            {
                Debug.Log("Should be 1");
                current = 1;
            }
        }
        else 
        {
            colliding = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        current = 0;
        movingtime = false;
        Debug.Log(current);
        Debug.Log("palyer stopped touched me");
    }
}
