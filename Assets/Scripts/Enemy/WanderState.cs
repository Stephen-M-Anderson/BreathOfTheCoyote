using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class WanderState : BaseState
{
    
     
    private Boximon _boximon;
    private Transform currentTarget;
    private Vector3 wanderTarget;
    private float wanderRange = 10f;
    private float IdleSwitchRange = 1.5f;
    private NavMeshHit navHit;
    public bool ChillTfOut = false;
    public WanderState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon; 
    }
    
    

    
    public override Type Tick()
    {
        
        if(_boximon.animationTimer < 0 && Time.time >  _boximon.nextCheck)
        {
            _boximon.myAnimator.SetBool("TakingHit",false);
            _boximon.myAnimator.SetBool("Idle", false);
            _boximon.myAnimator.SetBool("Movement", true);
            _boximon.myAnimator.SetBool("Attack", false);
        
            _boximon.nextCheck = Time.time + _boximon.checkRate;
             _boximon.enemyHit.Stop();
            _boximon.enemyWalking.Play();
            CheckIfToWander();
        }
        if( _boximon.animationTimer < 0 && Vector3.Distance(_boximon.navMeshAgent.destination, transform.position) < IdleSwitchRange )
        {
            _boximon.myAnimator.SetBool("TakingHit",false);
            _boximon.myAnimator.SetBool("Idle", true);
            _boximon.myAnimator.SetBool("Movement", false);
            _boximon.myAnimator.SetBool("Attack", false);

             _boximon.enemyHit.Stop();
            _boximon.enemyWalking.Stop();
        
        }

        if(!ChillTfOut && _boximon.animationTimer < 0 && Vector3.Distance(transform.position, _boximon.player.position) < _boximon.lookRadius)
        {
            _boximon.navMeshAgent.SetDestination(_boximon.player.position);
            return typeof(ChaseState);
        }
        return null;
  
    }

    public bool CheckIfToWander()
    {
        if(RandomWanderTarget(transform.position, wanderRange, out wanderTarget))
         {
            _boximon.navMeshAgent.enabled = true;  
            _boximon.navMeshAgent.SetDestination(wanderTarget);
            _boximon.enemyHit.Stop();
           _boximon.enemyWalking.Play();
            return true;
         }
         else
         {
            Debug.Log("No target");
            _boximon.navMeshAgent.SetDestination(wanderTarget);
            _boximon.enemyWalking.Stop();
            _boximon.enemyHit.Stop();
            return false;
         }
        
    }

    bool RandomWanderTarget(Vector3 center,  float range, out Vector3 result)
    {
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * wanderRange;
        if(NavMesh.SamplePosition(randomPoint,  out navHit, 10.0f, NavMesh.AllAreas))
        {
           
            result = navHit.position;   
            return true;
        }
        else
        {
            result = center;
            Debug.Log(navHit.distance);
            return false;
        }

    }
     
}