using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMages : MonoBehaviour
{
    public GameObject playerCopy;
    public GameObject Mage1;
    public GameObject Mage2;
    public GameObject Mage3;
    public GameObject Mage4;
    public float spawnDistance;
    private float currentDistance;

    void Start()
    {
        Mage1.SetActive(false);
        Mage2.SetActive(false);
        Mage3.SetActive(false);
        Mage4.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentDistance = Vector3.Distance(gameObject.transform.position, playerCopy.transform.position);
        if (currentDistance <= spawnDistance)
        {
            Mage1.SetActive(true);
            Mage2.SetActive(true);
            Mage3.SetActive(true);
            Mage4.SetActive(true);
            Destroy(gameObject);
        }
    }
}
