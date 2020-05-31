using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class AttackState : BaseState
{
    private Boximon _boximon;
   public AttackState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }

    public override Type Tick()
    {
            _boximon.myAnimator.SetBool("TakingHit",false);
            _boximon.myAnimator.SetBool("Idle", false);
            _boximon.myAnimator.SetBool("Movement", false);
            _boximon.myAnimator.SetBool("Attack", true);

            _boximon.enemyWalking.Stop();
            //_boximon.enemyMelee.PlayOneShot(_boximon.enemyMelee.clip)
            Debug.Log("enemyHit should be on");


        
            if(Vector3.Distance(transform.position, _boximon.player.position) > _boximon.lookRadius)
            {
                //Return to Wander state
                _boximon.navMeshAgent.enabled = true;
                return typeof(WanderState);
            }

            if(Vector3.Distance(transform.position, _boximon.player.position) > _boximon.stopDistance)
            {
                //return to Chase state
                _boximon.navMeshAgent.enabled = true;
                return typeof(ChaseState);
            }
            return typeof(AttackState);
    }
}
