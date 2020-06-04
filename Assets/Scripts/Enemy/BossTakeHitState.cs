﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class BossTakeHitState : BaseState
{
    private BoximonBoss _boximon;
    private float rotationSpeed;
    public BossTakeHitState(BoximonBoss boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }

    public override Type Tick()
    {
        Debug.Log("Still in Hit State");
        _boximon.navMeshAgent.SetDestination(transform.position);
        if(_boximon.TakeHitTimer <= 0)
        {   
            
            _boximon.TakeHitTimer = 1.0f;
            
            _boximon.myAnimator.SetBool("Movement",false);
            _boximon.myAnimator.SetBool("Idle",false);
            _boximon.myAnimator.SetBool("Attack",false);
            _boximon.myAnimator.SetBool("TakingHit",false);
        
             _boximon.myAnimator.SetTrigger("TakingHit 0");
            return typeof(BossAttack);
        }
        return typeof(BossAttack);
    }
}