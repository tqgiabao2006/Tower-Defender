using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;

public class Corn_Animation : MonoBehaviour
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
    public void UpdateAnim(CornState _cornState)
    {
        for(int i = 0; i <= (int)CornState.Corn_Upgrading_2_3; i++)
       {
         if((int)_cornState == i)
         {
          _animator.SetTrigger(_cornState.ToString());
         }
       }

    }
    
}
