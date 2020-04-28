using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;



public class Boximon : MonoBehaviour
{
    //General
    public Transform player;
    public float speed; 
    public Vector3 testPostion;

    public float stopDistance;

    //Wander State
    public float wanderTimer;
    public float max_wanderTimer;

    //Chase State
    public float lookRadius;

    public Vector3 Target{get; private set; }

    public StateMachine  stateMachine =>  GetComponent<StateMachine>();
    public  NavMeshAgent navMeshAgent => GetComponent<NavMeshAgent>();

    
    private void Awake()
    {
        //Default State set
        InitializeStateMachine();  
        testPostion = transform.position + Vector3.forward * 20; 
        SetTarget(testPostion);
        player = GameObject.Find("PlayerCharacter").transform;
    }
    void Update()
    {
        player = GameObject.Find("PlayerCharacter").transform;
        navMeshAgent.speed = speed;
    }

   private void InitializeStateMachine()
   {
       var states = new Dictionary<Type, BaseState>()
       {
           {typeof(WanderState), new WanderState(this)},
           {typeof(ChaseState), new ChaseState(this)},
           {typeof(AttackState), new AttackState(this)}
           /*
           {typeof(AvoidState), new AttackState(this)}
            */ 
       };

       GetComponent<StateMachine>().SetState(states);
   }

   public void SetTarget(Vector3 target)
   {
        Target =  target;
   }

   //If true, player position matches target so must transition out of this state.
   public bool IsTargetPlayer()
   {
           if(Target == player.position)
           return true;
        else
            return false;
   }

   void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
