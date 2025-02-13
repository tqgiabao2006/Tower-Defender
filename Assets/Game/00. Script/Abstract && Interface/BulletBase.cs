using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float _speed, _dmg, _lifeTime;
    protected Vector3 _direction;

    protected virtual void Start()
    { if(rb == null)
    {
     rb= this.GetComponent<Rigidbody2D>();

    }
     
    }
    public virtual void Update() 
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime <=0)
        {
            this.gameObject.SetActive(false);
        }
        
    }
   
   
    public void Init(float speed, float dmg, float lifeTime, Vector3 direction)
    {
       this._speed = speed;
       this. _dmg = dmg;
       this. _lifeTime = lifeTime;
       this._direction = direction;

    }
     protected virtual void FixedUpdate()
    {
        rb.velocity = _direction * _speed;
    }
    
    protected void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }
   
    protected private void OnTriggerEnter2D(Collider2D other) 
    {
       
            Boom(other.gameObject);
    }
    public abstract void Boom(GameObject target);
}
