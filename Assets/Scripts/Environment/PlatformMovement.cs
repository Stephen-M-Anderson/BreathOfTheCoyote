using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
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


        if (transform.position != points[current].transform.position)
        {
            Platmove = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
            transform.position = Platmove;
        }

        if (transform.position == points[current].transform.position && current == 1) 
        {
            current = 0;
        }
        if (transform.position == points[current].transform.position && current == 0)
        {
            current = 1;
        }

    }
}
