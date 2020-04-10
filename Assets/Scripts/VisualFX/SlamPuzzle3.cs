using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamPuzzle3 : MonoBehaviour
{
    public GameObject lit;
    public bool spawnvfx;

    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.GetComponent<Groundslammer>() != null)
        {
            gameObject.GetComponentInParent<StatHolder>().solve1 = true;
            GameObject floom = Instantiate(lit, transform.position, Quaternion.identity);
        }
    }
}
