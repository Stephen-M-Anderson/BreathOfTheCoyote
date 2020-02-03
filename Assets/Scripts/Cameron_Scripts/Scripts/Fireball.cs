using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Fireball : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    private Animator fireSpawn;
    public Transform handLocation;
    public float cooldownTimer;
    public AudioSource BGMSource;
    public Camera myCamera;


    // Start is called before the first frame update
    void Start()
    {
        // speed = 5f;
        cooldownTimer = 0f;
        fireSpawn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fireSpawn.SetBool("FireballAction", false);
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > 1.0f)

        {
            if (Input.GetAxis("Fireball") > 0)

            {
                cooldownTimer = 0f;
                fireSpawn.SetBool("FireballAction", true);
                //Invoke("fireballSpawn", 0.5f);


            }
        }
    }

    void fireballSpawn()
    {
        GameObject bullet = Instantiate(projectile, handLocation.position - 1.0f * handLocation.forward, Quaternion.identity);
        BGMSource.Play();

        float x = Screen.width / 2;
        float y = Screen.height / 2;
        var ray = myCamera.ScreenPointToRay(new Vector3(x, y, 0));
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * speed;
    }
}
