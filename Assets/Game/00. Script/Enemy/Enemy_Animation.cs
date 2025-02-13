using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using System;

public class Enemy_Animation : MonoBehaviour
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
    public void UpdateAnim()
    {
        _animator.SetTrigger("Enemy_GetHit");
    }
    
}

   



