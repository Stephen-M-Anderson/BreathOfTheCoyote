using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
public class ChaseState : BaseState
{
    private Boximon _boximon;

    public ChaseState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }
    private Transform IsEnemy(){
        return null;
    }

    public override Type Tick()
    {
        _boximon.speed =  13f;
        _boximon.myAnimator.SetBool("TakingHit",false);
        _boximon.myAnimator.SetBool("Idle", false);
        _boximon.myAnimator.SetBool("Attack", false);
        _boximon.myAnimator.SetBool("Movement", true);
        

        _boximon.enemyHit.Stop();
        _boximon.enemyWalking.Play();

       if( Vector3.Distance(transform.position, _boximon.player.position) > _boximon.lookRadius){
           
            return typeof(WanderState);
        }
        
        if(Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.lookRadius &&Vector3.Distance(transform.position, _boximon.player.position) > _boximon.stopDistance )
        { 
          
            _boximon.navMeshAgent.enabled = true;
            _boximon.SetTarget(_boximon.player.position);
            _boximon.navMeshAgent.SetDestination(_boximon.player.position);        
            return typeof(ChaseState);               
        }
        else if(Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.stopDistance){
            
            _boximon.navMeshAgent.enabled = false;
            return typeof(AttackState);
        }
        
        return null;
    }
}
