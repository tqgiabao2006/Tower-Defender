using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_SunFlower : BulletBase
{ 
    [SerializeField] float _rotateRate;
    
     public override void Boom(GameObject target)
    {
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if(isCanGetHit != null)
        {
          isCanGetHit.GetHit(_dmg);
        this.gameObject.SetActive(false);


        }
    
    }
   
    
    public override  void Update()
    {
         _lifeTime -= Time.deltaTime;
        if(_lifeTime <=0)
        {
            this.gameObject.SetActive(false);
        }else{

        transform.Rotate(Vector3.forward * 360 * Time.deltaTime * _rotateRate);

        }


    }
    
    
}
