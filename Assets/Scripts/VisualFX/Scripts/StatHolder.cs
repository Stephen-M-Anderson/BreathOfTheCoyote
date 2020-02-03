using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHolder : MonoBehaviour
{

    public bool solve1;
    public bool solve2;
    public bool solve3;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        solve1 = false;
        solve2 = false;
        solve3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (solve1 && solve2 && solve3)
        {
            animator.SetTrigger("MindComplete");
        }

    }
}
