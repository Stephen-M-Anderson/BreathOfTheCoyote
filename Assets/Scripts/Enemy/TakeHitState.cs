using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class TakeHitState : BaseState
{
    private Boximon _boximon;
    
   public TakeHitState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }

    public override Type Tick()
    {
        Debug.Log("Still in Hit State");
        _boximon.navMeshAgent.SetDestination(transform.position);
        if(_boximon.animationTimer <= 0)
        {   
            
            _boximon.animationTimer = 1.0f;
            
            _boximon.myAnimator.SetBool("Movement",false);
            _boximon.myAnimator.SetBool("Idle",false);
            _boximon.myAnimator.SetBool("Attack",false);
            _boximon.myAnimator.SetBool("TakingHit",false);
        
             _boximon.myAnimator.SetTrigger("TakingHit 0");
            return typeof(TakeHitState);
        }
            return typeof(WanderState);
    } 
}
