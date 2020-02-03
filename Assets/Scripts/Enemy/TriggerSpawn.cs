using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public Transform enemyPosition;
    public GameObject litAF;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public bool allDead;
    public Animator trophy;
    private int spawnCounter = 0;
    public bool permanentSleep;

    private GameObject playerRef;

    private void Start()
    {
        playerRef = GameObject.Find("PlayerCharacter");
    }

    private void Update()
    {
        if (allDead)
        {
            trophy.SetTrigger("StrengthComplete");
        }
    }

    //on entering the TriggerSpawn, spawns out the first enemy. increments the counter to 1
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 0)
            {

                Instantiate(enemy1, enemyPosition.position, enemyPosition.rotation);
                GameObject spawnvfx = Instantiate(litAF, transform.position, transform.rotation);
                Destroy(spawnvfx, 4.0f);
                spawnCounter = 1;
            }
        }
    }


    //while still in the TriggerSpawn, once it detects that the first enemy has died, it will spawn out the next enemy and increase the counter by 1
    //same will happen with the final spawn. after all enemies are dead....do something?
    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            if(permanentSleep == true && spawnCounter == 1)
            {
                Invoke("Spawn2", 4.0f);
                spawnCounter = 2;
                permanentSleep = false;
            }

            else if(permanentSleep == true && spawnCounter == 2)
            {
                Invoke("Spawn3", 4.0f);
                spawnCounter = 3;
                permanentSleep = false;
            }

            else if(permanentSleep == true && spawnCounter == 3)
            {
                allDead = true;
            }
        }
    }

    //The spawners for the enemy so they are set on delay due to invoke
    void Spawn2()
    {
        Instantiate(enemy2, enemyPosition.position, enemyPosition.rotation);
        GameObject spawnvfx = Instantiate(litAF, transform.position, transform.rotation);
        Destroy(spawnvfx, 4.0f);
    }

    void Spawn3()
    {
        Instantiate(enemy3, enemyPosition.position, enemyPosition.rotation);
        GameObject spawnvfx = Instantiate(litAF, transform.position, transform.rotation);
        Destroy(spawnvfx, 4.0f);
    }
}
