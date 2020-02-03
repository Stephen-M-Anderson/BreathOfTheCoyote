using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlat : MonoBehaviour
{
    public GameObject player;
    public GameObject elevator;
    private bool trigger;
    private bool touched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //trigger = player.GetComponent<PlayerCharacterController>().plat;

        if (touched)
        {
            player.transform.SetParent(gameObject.transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touched = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touched = false;
            player.transform.SetParent(null);
        }
    }
}
