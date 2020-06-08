using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckingBugFix : MonoBehaviour
{
    public GameObject playercharacter;
    public GameObject otherPOS;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playercharacter.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        playercharacter.transform.position = otherPOS.transform.position;

        Destroy(GameObject.Find("TempShit"));
    }
}
