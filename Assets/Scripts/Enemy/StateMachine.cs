using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class StateMachine : MonoBehaviour
{

    
    private Dictionary<Type, BaseState> _availableStates; 
    public BaseState CurrentState{get; private set;}
    public event Action<BaseState> OnStateChanged;
    

    public void SetState(Dictionary<Type, BaseState> states)
    {
        _availableStates = states;
    }

    
    // Update is called once per frame
    private void Update()
    {
       
        
        
        if(CurrentState == null)
        {
            Debug.Log("Current state is null");
            CurrentState = _availableStates.Values.First();
            Debug.Log("Current State is in default");
           
        }

        var nextState = CurrentState.Tick();
         
        if((nextState != null) && (nextState  != CurrentState?.GetType()))
        {
            SwitchToNewState(nextState);
           
        }
    }

    private void SwitchToNewState(Type nextState)
    {
        CurrentState =  _availableStates[nextState];
        Debug.Log("Switching to new state..");
        OnStateChanged?.Invoke(CurrentState);

    }
 }
