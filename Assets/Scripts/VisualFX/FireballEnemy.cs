using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FireballEnemy : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    private Animator fireSpawn;
    public Transform handLocation;
    public float cooldownTimer;
    public AudioSource BGMSource;
    //public Camera myCamera;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = 0f;
        //********New Animations here *****//
    }

    // Update is called once per frame
    void Update()
    {
        //********New Animations here *****//
        cooldownTimer += Time.deltaTime;
        target = GameObject.Find("mixamorig:Spine").GetComponent<Transform>();
        //******** Customize timer for spawning prefab, for now just spam that bitch *****//

        if (cooldownTimer > 3.0f)
        {
                cooldownTimer = 0f;
                //Invoke("fireballSpawn", 0.5f);
        }
    }

    void fireballSpawn()
    {
        //Debug.Log(target);
        GameObject bullet = Instantiate(projectile, handLocation.position + 2.0f * handLocation.forward, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (target.position - bullet.transform.position);
        //Debug.Log(target.position - bullet.transform.position);
        BGMSource.Play();
    }
}