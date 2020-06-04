using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSquare : MonoBehaviour
{

    public GameObject Parent;
    public GameObject vfx;
    public GameObject SpawnLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Parent.transform.childCount == 0)
        {
            GameObject Trial2Finish = Instantiate(vfx, SpawnLocation.transform.position, Quaternion.identity);
            Trial2Finish.name = "Trial2Finish";
            Destroy(Parent);
        }
    }
}
