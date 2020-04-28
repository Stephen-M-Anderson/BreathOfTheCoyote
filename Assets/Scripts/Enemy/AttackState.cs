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
        Debug.Log("Just entered Attack State");
        if(Vector3.Distance(transform.position, _boximon.player.position) < _boximon.lookRadius)
        {
            //Return to Wander state
            return typeof(WanderState);
        }

        if(Vector3.Distance(transform.position, _boximon.player.position) >= _boximon.stopDistance)
        {
            //return to Chase state
            return typeof(ChaseState);
        }
        return typeof(AttackState);

    }
}
