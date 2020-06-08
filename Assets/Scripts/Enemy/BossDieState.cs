using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class BossDieState : BaseState
{
    private BoximonBoss _boximon;
    private float rotationSpeed;
    public BossDieState(BoximonBoss boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }

    public override Type Tick()
    {
          _boximon.myAnimator.SetBool("Die", true);
        _boximon.navMeshAgent.enabled = false;
        _boximon.stateMachine.enabled = false;
        _boximon.DestroyBoximon();
        
    
        return null;
    }
}
