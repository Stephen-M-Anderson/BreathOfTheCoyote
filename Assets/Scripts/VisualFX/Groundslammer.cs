using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundslammer : MonoBehaviour
{
    private SphereCollider SphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        SphereCollider = gameObject.GetComponent<SphereCollider>();
        //Debug.Log(SphereCollider.radius);

        if (SphereCollider.radius < 2.0f)
        {
            SphereCollider.radius += 0.3f;
            //Debug.Log(SphereCollider.radius);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("runs");

        //Debug.Log(collision);
        if(collision.gameObject.GetComponent<SlamPuzzle1>() != null)
        {
            //Debug.Log("slampuzzle1");
            collision.gameObject.GetComponent<SlamPuzzle1>().gameObject.GetComponentInParent<StatHolder>().solve1 = true;
            collision.gameObject.GetComponent<SlamPuzzle1>().spawnvfx = true;
        }
       else if (collision.gameObject.GetComponent<SlamPuzzle2>() != null)
        {
            collision.gameObject.GetComponent<SlamPuzzle2>().gameObject.GetComponentInParent<StatHolder>().solve2 = true;
            collision.gameObject.GetComponent<SlamPuzzle2>().spawnvfx = true;
        }
        else if (collision.gameObject.GetComponent<SlamPuzzle3>() != null)
        {
            collision.gameObject.GetComponent<SlamPuzzle3>().gameObject.GetComponentInParent<StatHolder>().solve3 = true;
            collision.gameObject.GetComponent<SlamPuzzle3>().spawnvfx = true;
        }


    }
}
