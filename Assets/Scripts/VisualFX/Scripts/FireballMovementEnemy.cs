using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.Audio;


public class FireballMovementEnemy : MonoBehaviour
{
    //Notes for future: change it so effects aren't spawned in single burst
    public float speed;
    public VisualEffect myEffect;
    public float time;
    private Rigidbody rb;
    //public GameObject puzzlehold;
    public GameObject explosion;
    public static readonly string DirectionBall = "Direction";
    public static readonly string DirectionTail = "DirectionTail";
    public AudioSource BGMSource;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        rb = GetComponent<Rigidbody>();
        Debug.Log("Speed is: " + speed);
        //rb.velocity = ((Camera.main.transform.forward * speed) + new Vector3(3,0,0));
       // float x = Screen.width / 2;
       // float y = Screen.height / 2;
       // var ray = myCamera.ScreenPointToRay(new Vector3(x, y, 0));
       // Debug.Log("ray is" + ray);
       // rb.velocity = ray.direction * speed;
        myEffect.SetVector3(DirectionBall, -rb.velocity);
        myEffect.SetVector3(DirectionTail, -rb.velocity*2);
      //  rb.velocity = (target.position - transform.position).normalized * speed;



        // GameObject puzzlemaster = gameObject.GetComponent<StatHolder>;

    }

    // Update is called once per frame
    void Update()
    {

        //  transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        // rigidbody.AddForce(speed);

        // Destroy(gameObject, 2.0f);

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


        // Destroy(collision.gameObject);

        //Switch this over to programs on the pillars end, and when they are hit, solve is set to true.
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("lol this nerd just took damage");
            collision.gameObject.GetComponent<Player>().DamagePlayer(2);
        }
        GameObject blowup = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(blowup, 3.0f);

       BGMSource.Play();
        //Come back to later down the line. The attampt going on here is to try and blend the time between the ball and the explosion
        Destroy(gameObject);
        //Destroy(gameObject, .001f);
        time = 0f;

    }
}
