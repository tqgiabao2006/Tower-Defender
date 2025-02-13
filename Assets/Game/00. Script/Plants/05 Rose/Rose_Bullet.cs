using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose_Bullet : BulletBase
{
    [SerializeField] float _speedDecrease;

     public override void Boom(GameObject target)
    {
        
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        EnemyBase enemy_Moving = target.GetComponent<EnemyBase>();
        if(isCanGetHit != null)
        {
          isCanGetHit.GetHit(_dmg);
          this.gameObject.SetActive(false);
          enemy_Moving.Init(_speedDecrease);
          


        }
    
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        Boom(other.gameObject);
        
    }
    
}
