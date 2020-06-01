using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class AttackState : BaseState
{
    private Boximon _boximon;

    private float str = 100;
    private float strength;

    public float rotationSpeed = 20;
    
   public AttackState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }

    public override Type Tick()
    {
         RotateTowards(_boximon.player);
        _boximon.speed = 0f;
        _boximon.myAnimator.SetBool("Attack", false);
         if (_boximon.myAnimator.GetBool("Attack"))  //next three if statements check if the attack animation bool is borken or frozen and sets them to false.
        {
            _boximon.AttackTimer += Time.deltaTime;
        }
        if (!_boximon.myAnimator.GetBool("Attack"))
        {
            _boximon.AttackTimer = 0f;
        }        
        if (_boximon.myAnimator.GetBool("Attack") && _boximon.AttackTimer >= 1.3f)
        {
            _boximon.myAnimator.SetBool("Attack", false);
            _boximon.myAnimator.SetBool("Idle", true);
            _boximon.AttackTimer = 0f;
        }
            

            Debug.Log("enemyHit should be on");
        
            if(Vector3.Distance(transform.position, _boximon.player.position) > _boximon.lookRadius)
            {
                //Return to Wander state
                _boximon.navMeshAgent.enabled = true;
                return typeof(WanderState);
            }

            if(Vector3.Distance(transform.position, _boximon.player.position) >= _boximon.stopDistance)
            {
                //return to Chase state
                _boximon.navMeshAgent.enabled = true;
                return typeof(ChaseState);
            }
            else if(_boximon.AttackTimer <= 0f){
                /*
                var targetRotation = Quaternion.LookRotation (_boximon.player.position - transform.position);
                str = Mathf.Min (strength * Time.deltaTime, 1);
                transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
                */
                
               
                _boximon.myAnimator.SetBool("Movement", false);
                _boximon.myAnimator.SetBool("Attack", true);

                _boximon.enemyWalking.Stop();
                return typeof(ChaseState);                
            }
            
            return typeof(AttackState);
    }
    private void RotateTowards (Transform target) {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
     }
}
