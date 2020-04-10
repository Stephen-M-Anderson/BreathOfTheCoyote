using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For some of the platforms in the game, they are only activated by the player standing on them. This script enables movement if it is touched by the player
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
