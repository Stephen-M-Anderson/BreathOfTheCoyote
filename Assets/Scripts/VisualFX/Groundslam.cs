using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundslam : MonoBehaviour
{
    public GameObject groundv1;
    private Animator grndslamAni;
    public GameObject player;
    private bool temp;
    CharacterController characterController;
    public bool groundedcheck;
    private float cooldown;
    private float timeClip;
    private Vector3 moveDirection = Vector3.zero;
    public AudioSource BGMSource;
    private bool yeshereIammakinganothergoddamnbool;
    //public PlayerCharacterController playerCharacterController;


    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        //playerCharacterController = GetComponent<PlayerCharacterController>
        grndslamAni = GetComponent<Animator>();
        cooldown = 0f;
        
        yeshereIammakinganothergoddamnbool = true;
    }

    // Update is called once per frame
    void Update()
    {
        grndslamAni.SetBool("GroundSlam", false);
        cooldown += Time.deltaTime;

        //Debug.Log("GROUNDSLAM: " + yeshereIammakinganothergoddamnbool);
        //Debug.Log("ANIMATION: " + grndslamAni.GetBool("GroundSlam"));

        groundedcheck = GetComponent<PlayerCharacterController>().isOnGround;
        if (cooldown > 2)
        {

            if (Input.GetAxis("Groundslam") != 0 && yeshereIammakinganothergoddamnbool == true)
            {
                yeshereIammakinganothergoddamnbool = false;
                grndslamAni.SetBool("GroundSlam", true);
                //Invoke("groundEffect", 1.1f);


            }

        }
        /*
        if (temp)
        {
            if (groundedcheck)
            {
                GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);
                Destroy(slamvfx, 2.0f);
                temp = false;

            }
        }
        */
        //Placeholder
        //This program isn't set yet as nothing is prepared to use it
        //If an object that has a certain attachment to it is nearby when it is pressed, then something happens

    }

    void groundEffect()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        GameObject slamvfx = Instantiate(groundv1, transform.position + (3f * transform.forward), transform.rotation);
        Destroy(slamvfx, 2.0f);
        // BGMSource.Play();
        grndslamAni.SetBool("GroundSlam", false);
        cooldown = 0f;
        yeshereIammakinganothergoddamnbool = true;
    }
}
