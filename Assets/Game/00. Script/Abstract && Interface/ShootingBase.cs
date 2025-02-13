using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public abstract class ShootingBase : MonoBehaviour
{   [SerializeField] protected LayerMask _enemyCheck;
     protected Vector3 _direction;
     [Header("-----------Level1 Config--------------")]
    [SerializeField] protected float _basicRadius;
    float _radius;
    [SerializeField] protected float _shootingCoolDown, _currentShootingTime, _speed, _dmg, _lifeTime;
    
    public bool isShooting(float radius)
    {   _radius = radius;
        return Physics2D.OverlapCircle(this.transform.position, radius, _enemyCheck);
    }

    public abstract void Shooting();

   
}
