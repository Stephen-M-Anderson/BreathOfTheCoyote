using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class WanderState : BaseState
{
    private Boximon _boximon;
    private Vector3 testPostion;
    public WanderState(Boximon boximon) : base(boximon.gameObject)
    {
        _boximon = boximon;
    }
    
    

    
    public override Type Tick()
    {
        //Start or continue wander time for this state
        _boximon.wanderTimer += Time.deltaTime;
        Debug.Log("Looking for random position");
        testPostion = FindRandomPosition(transform.position, 15.0f,-1);

        if(IsPositionValid(testPostion) && _boximon.wanderTimer >= _boximon.max_wanderTimer){
            
            //No object in the position to Boximon object
            _boximon.testPostion = testPostion;
            //set new target as the Boximon object tested position
            _boximon.SetTarget(_boximon.testPostion);
            _boximon.navMeshAgent.SetDestination(_boximon.Target);
            _boximon.wanderTimer = 0;
            return null;
        }
        
        //State Action
        Debug.Log("In wander state");
        if(Vector3.Distance(transform.position, _boximon.player.transform.position) <= _boximon.lookRadius){
            Debug.Log("Transitioning to chase state");
            _boximon.SetTarget(_boximon.player.position);
            _boximon.navMeshAgent.SetDestination(-_boximon.Target);
             return typeof(ChaseState);
        }

        _boximon.navMeshAgent.SetDestination(_boximon.Target);
        return null;
    
    }

        //Find new random Vec 3 Position to test for destination switch.
        public static Vector3 FindRandomPosition (Vector3 origin, float distance, int layermask) {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
            randomDirection += origin;
            NavMeshHit navHit;
            NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
            return navHit.position;
        }

        public bool IsPositionValid(Vector3 nextPosition)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, nextPosition, out hit))
            {
                Debug.DrawRay(transform.position, nextPosition, Color.red);
                return true;  
            }
            return false;   
            
        }
}