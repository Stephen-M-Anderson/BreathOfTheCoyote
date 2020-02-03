/*
  Combo script for both player and enemy that will allow three combo moves to be executed
  Combo moves for player will be determined by buttons pressed
  Combo moves for enemy ai will be auto generated every five seconds
  Checks for enemy ai combo:
     (1.) isenemybeinghit
     (2.) isplayerbeing hit
     (3.) isplayerinrange
     (4.) isattack
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyCombo : MonoBehaviour
{
    Animator meleeAction;
    private int attackCounter;
    private float cooldown;
    private float reset;

    public float weaponDamage;

    public int attackValue = 0;
    private bool combo = false;
    private bool startTimer = false;
    private float timer = 0.0f;

    int numClicks;
    bool canClick;

    private AudioSource attackSource;
    public AudioClip attack1;
    public AudioClip attack2;
    public AudioClip attack3;

    void Start()
    {
        meleeAction = gameObject.GetComponent<Animator>();
        numClicks = 0;
        canClick = true;

        attackSource = GameObject.Find("PlayerAttack").GetComponent<AudioSource>();
    }

    //Weapon animations and giving damage to the Weapon
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ComboStarter();
        }
    }

    public void ComboStarter()
    {
        meleeAction.SetBool("IsAttacking", true);
        if (canClick)
        {
            numClicks++;
        }

        if(numClicks == 1)
        {
            meleeAction.SetInteger("AttackValue", 1);
            attackSource.clip = attack1;
            attackSource.Play();
        }
    }

    public void ComboCheck()
    {
        canClick = false;
        

        if(meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack1") && numClicks == 1)
        {
            meleeAction.SetBool("IsAttacking", false);
            meleeAction.SetInteger("AttackValue", 0);
            canClick = true;
            numClicks = 0;

            attackSource.Stop();
            attackSource.clip = attack1;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack1") && numClicks >= 2)
        {
            attackSource.clip = attack2;
            attackSource.Play();

            meleeAction.SetInteger("AttackValue", 2);
            canClick = true;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack2") && numClicks == 2)
        {
            meleeAction.SetBool("IsAttacking", false);
            meleeAction.SetInteger("AttackValue", 0);
            canClick = true;
            numClicks = 0;

            attackSource.Stop();
            attackSource.clip = attack1;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack2") && numClicks >= 3)
        {

            meleeAction.SetInteger("AttackValue", 3);
            canClick = true;

            attackSource.clip = attack3;
            attackSource.Play();
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack3"))
        {
            meleeAction.SetBool("IsAttacking", false);
            meleeAction.SetInteger("AttackValue", 0);
            canClick = true;
            numClicks = 0;

            attackSource.Stop();
            attackSource.clip = attack1;
        }
    }

    public void SetAttacking(bool attacking)
    {
        meleeAction.SetBool("IsAttacking", attacking);
    }
}
