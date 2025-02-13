using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ChildCorn : BulletBase
{ 
     public override void Boom(GameObject target)
    {
        
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if(isCanGetHit != null)
        {
          isCanGetHit.GetHit(_dmg);
        this.gameObject.SetActive(false);


        }
    
    }
}
