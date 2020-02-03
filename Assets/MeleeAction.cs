using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAction : MonoBehaviour
{
    Animator meleeAction;
    private int meleeCounter = 0;

    void Start()
    {
        meleeAction = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        meleeAction.ResetTrigger("Melee");
        if (Input.GetMouseButton(0) && meleeCounter == 0)
        {
            meleeAction.SetTrigger("Melee");
            meleeCounter = 1;
            
            
            
        }

        


        
        
    }
}
