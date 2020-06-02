using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class BossAttack : BaseState
{
    private BoximonBoss _boximon;
    private float rotationSpeed;
    public BossAttack(BoximonBoss boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }

    public override Type Tick()
    {
        RotateTowards(_boximon.player);
        _boximon.speed = 0f;
        _boximon.myAnimator.SetBool("Attack", false);

      
        
            

            Debug.Log("enemyHit should be on");
             if(Vector3.Distance(transform.position, _boximon.player.position) >= _boximon.lookRadius)
            {
                _boximon.myAnimator.SetBool("Attack", false);
                _boximon.myAnimator.SetBool("Movement", false);
                _boximon.myAnimator.SetBool("Attack 2", false);
                _boximon.myAnimator.SetBool("Idle", true);
                return typeof(BossAttack);
            }
            if(Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.lookRadius)
            {
                _boximon.FirstWave.SetActive(true);
                
            }
            if(Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.SecondWaveDistance)
            {
               _boximon.SecondWave.SetActive(true);
            }
             if(Vector3.Distance(transform.position, _boximon.player.position) >= _boximon.stopDistance  && Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.ChaseDistance)
            {
                _boximon.myAnimator.SetBool("Idle", false);
                _boximon.myAnimator.SetBool("Attack", false);
                _boximon.myAnimator.SetBool("Attack 2", false);
                _boximon.myAnimator.SetBool("Movement", true);

                _boximon.navMeshAgent.SetDestination(_boximon.player.position);
               _boximon.speed = 30;
               return typeof(BossAttack);
            }

            if(_boximon.attackTimer <= 0f &&Vector3.Distance(transform.position, _boximon.player.position) <= _boximon.stopDistance)
            {
                _boximon.navMeshAgent.SetDestination(transform.position);
                _boximon.myAnimator.SetBool("Idle", false);
                _boximon.myAnimator.SetBool("Movement", false);
                _boximon.myAnimator.SetBool("Attack 2", true);
                _boximon.myAnimator.SetBool("Attack", true);

                _boximon.attackTimer = 7.0f;

                
                return typeof(BossAttack);
               
            }
            else{
                 _boximon.myAnimator.SetBool("Idle", true);
                _boximon.myAnimator.SetBool("Movement", false);
                _boximon.myAnimator.SetBool("Attack 2", false);
                _boximon.myAnimator.SetBool("Attack", false);
                
                return typeof(BossAttack);
        }
    }
    
        private void RotateTowards(Transform target) {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
     }
}
