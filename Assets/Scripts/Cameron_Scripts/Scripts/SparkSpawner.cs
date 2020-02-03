using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class SparkSpawner : MonoBehaviour
{
    public GameObject sparkie;


    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>() != null)
        {
            GameObject swordspark = Instantiate(sparkie, gameObject.transform.position, Quaternion.identity);
        }
    }
}
