using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Bullet : BulletBase
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

    public override void Update()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime <=0)
        {
            this.gameObject.SetActive(false);
        }

    float _angle = (Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg) + 180;
    this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x, this.transform.rotation.y, _angle));

    }
    


}
