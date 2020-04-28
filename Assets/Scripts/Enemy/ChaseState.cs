using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
public class ChaseState : BaseState
{
    private Boximon _boximon;
    private Vector3 testPostion;
    public ChaseState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }
    private Transform IsEnemy(){
        return null;
    }

    public override Type Tick()
    {
        Debug.Log("In chase state");
       if(Vector3.Distance(transform.position, _boximon.player.position) > _boximon.lookRadius){
            Debug.Log("Transitioning to Wander state");
            _boximon.navMeshAgent.enabled = false;
            return typeof(WanderState);
        }
        
        if(Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.lookRadius &&Vector3.Distance(transform.position, _boximon.player.position) > _boximon.stopDistance )
        { 
            Debug.Log("Player seen");
            _boximon.navMeshAgent.enabled = true;
            _boximon.SetTarget(_boximon.player.position);
            _boximon.navMeshAgent.SetDestination(_boximon.Target);        
            return typeof(ChaseState);               
        }
        else if(Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.stopDistance){
            Debug.Log("Player in Range");
            _boximon.navMeshAgent.enabled = false;
            return typeof(AttackState);
        }
        
        return null;
    }
}
