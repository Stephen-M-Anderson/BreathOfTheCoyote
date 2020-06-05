using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script spawns the enemy when you come into the area. There is a trigger surrounding the strength trial
public class TriggerSpawn : MonoBehaviour
{
    public Transform enemyPosition;
 //   public GameObject litAF;
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

                GameObject Enemy1 = Instantiate(enemy1, enemyPosition.position, enemyPosition.rotation);
                Enemy1.name = "Enemy1";
               // GameObject spawnvfx = Instantiate(litAF, transform.position, transform.rotation);
               // Destroy(spawnvfx, 4.0f);
                spawnCounter = 1;
            }
        }
    }


    //while still in the TriggerSpawn, once it detects that the first enemy has died, it will spawn out the next enemy and increase the counter by 1
    //same will happen with the final spawn. after all enemies are dead....do something?
    //TEMP FIX COME BACK TO AND ADD A DELAY
    //Problem here is the checks we had previously didn't change, so second enemy would never spawn. 
    //Initial attempt was simply changing to the gameobject.find, but it would spawn literal tons of enemies.
    //Need to add a delay, but we can't have it spawn an infinite amount of enemies
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(spawnCounter + " " + permanentSleep);
        if(other.gameObject.tag == "Player")
        {
            if(GameObject.Find("Enemy1") == null && spawnCounter == 1)
            {

                Invoke("Spawn2", 0f);
                permanentSleep = false;
            }

            else if(GameObject.Find("Enemy2") == null && spawnCounter == 2)
            {
                Invoke("Spawn3", 0f);
                permanentSleep = false;
            }

            else if(GameObject.Find("Enemy3") == null && spawnCounter == 3)
            {
                allDead = true;
            }
        }
    }

    //The spawners for the enemy so they are set on delay due to invoke
    void Spawn2()
    {
        GameObject Enemy2 = Instantiate(enemy2, enemyPosition.position, enemyPosition.rotation);
        Enemy2.name = "Enemy2";
        spawnCounter = 2;


        // GameObject spawnvfx = Instantiate(litAF, transform.position, transform.rotation);
        //  Destroy(spawnvfx, 4.0f);
    }

    void Spawn3()
    {
      GameObject Enemy3 =  Instantiate(enemy3, enemyPosition.position, enemyPosition.rotation);
        Enemy3.name = "Enemy3";
        spawnCounter = 3;

        //   GameObject spawnvfx = Instantiate(litAF, transform.position, transform.rotation);
        //  Destroy(spawnvfx, 4.0f);
    }
}
