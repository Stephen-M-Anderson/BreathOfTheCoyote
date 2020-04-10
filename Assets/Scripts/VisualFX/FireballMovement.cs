using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.Audio;


public class FireballMovement : MonoBehaviour
{
    //Notes for future: change it so effects aren't spawned in single burst
    public float speed;
    public VisualEffect myEffect;
    public float time;
    private Rigidbody rb;
    public GameObject explosion;
    public static readonly string DirectionBall = "Direction"; //VFX graph variable
    public static readonly string DirectionTail = "DirectionTail"; //VFX graph variable
    public AudioSource BGMSource;



    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        rb = GetComponent<Rigidbody>();
        //these 2 lines are for vfx graph they handle the direction the particles go
        myEffect.SetVector3(DirectionBall, -rb.velocity);
        myEffect.SetVector3(DirectionTail, -rb.velocity*2);
    }

    // Update is called once per frame
    void Update()
    {
        //After 3 seconds the fireball explodes if it doesn't hit anything
            time = time + Time.deltaTime;

            if (time > 3)
            {
            GameObject blowup = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(blowup, 3.0f);
            time = 0f;
            BGMSource.Play();
            Destroy(gameObject);
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //This is when it hits an object the fireball is deleted and the explosion is spawned
        //Damage is done in other scripts
        GameObject blowup = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);//spawns explosion wherever it hit
        Destroy(blowup, 3.0f);// explosion goes away after 3 seconds

       BGMSource.Play(); //Audio explosion sound
        //Come back to later down the line. The attampt going on here is to try and blend the time between the ball and the explosion
        Destroy(gameObject);
        time = 0f;
    }
}
