using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamPuzzle1 : MonoBehaviour
{

    public GameObject lit;
    public bool spawnvfx = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (spawnvfx == true)
        {
            GameObject floom = Instantiate(lit, transform.position, Quaternion.identity);
            spawnvfx = false;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
    }
}
