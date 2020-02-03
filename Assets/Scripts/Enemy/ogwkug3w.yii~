using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("AI");
        player = GameObject.FindWithTag("Player");
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(player.transform);
        transform.Translate(0, 0, 8 * Time.deltaTime);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            collision.gameObject.GetComponent<TriggerSpawn>().firstDeath = true;
        }
    }

}
