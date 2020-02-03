using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzle2 : MonoBehaviour
{
    public GameObject lit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<FireballMovement>() != null && gameObject.GetComponentInParent<StatHolder>().solve2 == false)
        {
            gameObject.GetComponentInParent<StatHolder>().solve2 = true;
            GameObject floom = Instantiate(lit, transform.position, Quaternion.identity);

        }
    }
}
