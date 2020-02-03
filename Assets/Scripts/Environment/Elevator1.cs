using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator1 : MonoBehaviour
{
    public GameObject[] points;
    public int current = 0;
    public float speed;
    public Vector3 Platmove;
    public float dist;

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector3.Distance(transform.position, points[current].transform.position);


        if (current !=0 && transform.position != points[current].transform.position)
        {
            Platmove = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
            transform.position = Platmove;
        }
        if (current == 0 && transform.position != points[current].transform.position)
        {
            Platmove = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
            transform.position = Platmove;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            current = 1;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            current = 1;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        current = 0;
    }

}
