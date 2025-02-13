using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_Animation : MonoBehaviour
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
    public void UpdateAnim(BossState _bossState)
    {
       
         if(_bossState.ToString() == "Boss_Casting")
        {     
            for(int i = 0; i <= (int)BossState.Boss_Casting; i++)
            {
                if(i == (int)_bossState)
                {
                    _animator.SetBool(_bossState.ToString(), true);
                }else
                {
                    _animator.SetBool(_bossState.ToString(), false);
                }
               
            }
        
        }else
        {
            _animator.SetBool("Boss_Casting", false);
              
            for(int i = 0; i <= (int)BossState.Boss_Casting; i++)
            {
                if(i==(int)_bossState)
                {
                    _animator.SetTrigger(_bossState.ToString());
                }

            }

        }
    }
    
}
