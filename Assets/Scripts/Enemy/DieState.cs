using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Linq;

public class DieState : BaseState
{
    private Boximon _boximon;
    public DieState(Boximon boximon) : base(boximon.gameObject)
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
