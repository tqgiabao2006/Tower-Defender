using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Animation : MonoBehaviour
{
    Animator _animator;
    public Action<string> _eventAction = null;

    private void Awake() 
    {
        if(_animator ==null)
        {
            _animator = this.GetComponent<Animator>();
        }
        
        
    }
    public void CallEvent(string name)
    {
        if(_eventAction !=null)
        {
          _eventAction.Invoke(name);


        }
    }
    public void UpdateAnim(ArcherState _archerState)
    {
        for(int i = 0; i <= (int)ArcherState.Player_Run; i++)
       {
         if((int)_archerState == i)
         {
          _animator.SetTrigger(_archerState.ToString());
         }
       }    

    }
    public void Holding(ArcherState _archerState)
    {
        if(_archerState.ToString()== "Player_Holding")
        _animator.SetBool(_archerState.ToString(), true);
        else 
        _animator.SetBool("Player_Holding", false);


    }
    
}


    

