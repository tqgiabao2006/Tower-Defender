using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Apple_Animation : MonoBehaviour
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
    public void UpdateAnim(AppleState _appleState)
    {
        for(int i = 0; i <= (int)AppleState.Apple_Upgrading_2_3; i++)
       {
         if((int)_appleState == i)
         {
          _animator.SetTrigger(_appleState.ToString());
         }
       }

    }
    
    
}


