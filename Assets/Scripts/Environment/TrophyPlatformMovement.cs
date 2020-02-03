using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyPlatformMovement : MonoBehaviour
{
    public GameObject Trophy;
    public TriggerPlatforms tP;
    public float speedS = 10.0f;
    public float movingtime = 3.0f;
    private float standbytime = 1.0f;
    private float timer;
    private bool startMovingForward;
    private bool movedonedown;
    private bool movedone;
    private bool disabled;
    private bool startMovingdown;
    private bool standbydone;
    private bool trophydone;



    private Rigidbody rb;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();    // Initialize the Rigidbody2D object with this gameobject's Rigidbody2D component that is attached to it in the inspector.
        movedone = false;
        movedonedown = false;
        startMovingForward = false;
        disabled = false;
        startMovingdown = false;
        standbydone = false;
        trophydone = true;
        timer = 0;
    }

    /// <summary>
    /// Fixed Update is called once per fixed frame.
    /// Use physical behaviors (or anything involving the rigidbody) in this function.
    /// </summary>
    void FixedUpdate()
    {
        if(startMovingForward)
        {
            Vector3 pmovement = new Vector3(0.0f, 1f, 0.0f);
            pmovement = pmovement * speedS * Time.deltaTime;
            pmovement = transform.worldToLocalMatrix.inverse * pmovement;
            rb.MovePosition(transform.position + pmovement);
        }
        if (startMovingdown)
        {
            Vector3 pmovement = new Vector3(0.0f, 1f, 0.0f);
            pmovement = pmovement * speedS * Time.deltaTime;
            pmovement = transform.worldToLocalMatrix.inverse * pmovement;
            rb.MovePosition(transform.position - pmovement);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (!Trophy.activeInHierarchy && trophydone)
        {
            Debug.Log("DISABLED");
            standbydone = true;
        }

        if (standbydone && !disabled)
        {
            timer += Time.deltaTime;
            if (timer >= standbytime)
            {
                timer = 0;
                disabled = true;
                standbydone = false;
                trophydone = false;
            }
        }

        if (disabled && !movedonedown)
        {
            startMovingdown = true;
            timer += Time.deltaTime;
            if (timer >= movingtime)
            {
                timer = 0;
                startMovingdown = false;
                movedonedown = true;
            }
        }

        if (tP.startMove && !movedone)
        {
            startMovingForward = true;
            timer += Time.deltaTime;
            if (timer >= movingtime)
            {
                timer = 0;
                startMovingForward = false;
                movedone = true;
            }
        }
    }
}
