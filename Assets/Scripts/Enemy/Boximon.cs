using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using System.Linq;



public class Boximon : MonoBehaviour
{

    //General
    [HideInInspector]
    public Transform player;
    public float speed;
    public float maxHealth; 
    public float currentHealth;

    [HideInInspector]

    public AudioSource enemyWalking;

    [HideInInspector]
    public AudioSource enemyHit;

    [HideInInspector]
    public AudioSource enemyMelee;
    
    [HideInInspector]
    public AudioSource enemyDeath;


    public float  checkRate;

    [HideInInspector]
    public float nextCheck;

    [HideInInspector]
    public float TakeHitTimer;
    public float AttackTimer;
        

    public float stopDistance;

    //Wander State
    public float MinWander;
    public float MaxWander;

    //Chase State
    public float lookRadius;
    //Attack state
    public float attackTimer;
    

    public Vector3 Target{get; private set; }

    public StateMachine  stateMachine =>  GetComponent<StateMachine>();
    public  NavMeshAgent navMeshAgent => GetComponent<NavMeshAgent>();
    public Animator myAnimator => GetComponent<Animator>();
    private Animator playerAnimator;

    [HideInInspector]
    public Collider Playercol;

    [HideInInspector]
    public GameObject playerWeaponHitBox;
    
    private void Awake()
    {
        //Default State set
        InitializeStateMachine();  
        currentHealth = maxHealth;
        player = GameObject.Find("PlayerCharacter").transform;
        playerAnimator = player.GetComponent<Animator>();
        checkRate = UnityEngine.Random.Range(MinWander, MaxWander);

        enemyDeath = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
        enemyMelee = GameObject.Find("EnemyMelee").GetComponent<AudioSource>();
        enemyHit = GameObject.Find("EnemyHit").GetComponent<AudioSource>();
        enemyWalking = GameObject.Find("EnemyWalking").GetComponent<AudioSource>();

        Playercol = player.GetComponent<CapsuleCollider>();

        playerWeaponHitBox = GameObject.Find("WeaponHitBox");

    }
    void Update()
    {
        Debug.Log(myAnimator.GetBool("Attack"));

        player = GameObject.Find("PlayerCharacter").transform;
        navMeshAgent.speed = speed;
        TakeHitTimer = TakeHitTimer - Time.deltaTime;
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (TakeHitTimer < 0 && 
        (other.gameObject.CompareTag("Weapon") && playerAnimator.GetInteger("AttackValue") == 1 ||
        other.gameObject.CompareTag("Weapon") && playerAnimator.GetInteger("AttackValue") == 2  ||
        other.gameObject.CompareTag("Weapon") && playerAnimator.GetInteger("AttackValue") == 3  ||
        other.gameObject.GetComponent<FireballMovement>() != null))
        {
            DamageStateChange();
            if(currentHealth <= 0)
            {
            stateMachine.enabled = false;
            enemyDeath.Play();
            myAnimator.Play("Die");
            Invoke("Dead", 2.0f);
            } 
        }
    }

   private void InitializeStateMachine()
   {
     var states = new Dictionary<Type, BaseState>()
       {
           {typeof(WanderState), new WanderState(this)},
           {typeof(ChaseState), new ChaseState(this)},
           {typeof(AttackState), new AttackState(this)},
           {typeof(TakeHitState), new TakeHitState(this)},
           {typeof(DieState), new DieState(this)}
       };

       stateMachine.SetState(states);
   }

   public void DestroyBoximon()
   {
       Destroy(this.gameObject, 4.0f);
   }

   //Override state Machine cycle for damage taking
   private void DamageStateChange()
   {
       currentHealth -= 5.0f;
       var states = new Dictionary<Type, BaseState>()
       {
           {typeof(TakeHitState), new TakeHitState(this)},
           {typeof(DieState), new DieState(this)}
       };
       if(currentHealth <= 0){
           stateMachine.SwitchToNewState(states.Values.Last().Tick());
       }
       else{
           stateMachine.SwitchToNewState(states.Values.First().Tick());
       }
   }
   public void SnackTime()
    {
        attackTimer = 0f;
        Playercol.gameObject.GetComponent<Player>().DamagePlayer(3);
    }
   public void AudioNoise()
    {
        enemyMelee.Play();
    }

   public void SetTarget(Vector3 target)
   {
        Target =  target;
   }

   void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    public void StopAnim()
    {
        Debug.Log("Stopanim has been seen");
        myAnimator.SetBool("Attack", false);
        myAnimator.SetBool("Idle", true);
        Debug.Log("Exiting");
    }
}
