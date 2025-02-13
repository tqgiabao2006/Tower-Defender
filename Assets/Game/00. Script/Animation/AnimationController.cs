 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : AnimationBase
{
   
    public override void UpdateAnim(PlayerState playerState)
    {
       for(int i = 0; i <= (int)PlayerState.Upgrading_2_3; i++)
       {
         if((int)playerState == i)
         {
          _animator.SetTrigger(playerState.ToString());
         }
       }

    }
        
}


