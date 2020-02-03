using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatforms : MonoBehaviour
{
    public bool startMove;
    private bool nottouched;
    // Start is called before the first frame update
    void Start()
    {
        startMove = false;
        nottouched = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Player" && nottouched)
        {
            Debug.Log("startmove");

            startMove = true;
            nottouched = false;
        }
    }
}
