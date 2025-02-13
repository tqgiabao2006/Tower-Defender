using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AnimationBase : MonoBehaviour
{
   

    protected Animator _animator;
    public Action<string> _eventAction = null;

    protected void Awake() 
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
    public abstract void UpdateAnim(PlayerState playerState);
}
