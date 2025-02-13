using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Controller_ChildCorn : MonoBehaviour, IGetHit
{
  [SerializeField] List<BulletBase> _childBullet = new List<BulletBase>();
  [SerializeField] LayerMask _enemyCheck;
  [SerializeField] float _lifeTime;
  float _childHP, _amor, _currentCD;

  Vector3 _childPos;
  Rigidbody2D rb;
  [SerializeField] int _currentLevel;

  [Header("-------Shooting LV2 Config--------")]
  [SerializeField] float _lv2Dmg;
  [SerializeField] float _lv2Speed, _lv2CD, _lv2Radius;

  [Header("-------Shooting LV3 Config--------")]

  [SerializeField] float _lv3Dmg;
  [SerializeField] float _lv3Speed, _lv3CD, _lv3Radius;
  private bool _shoot;

   private void Start()
   {
       rb = this.GetComponent<Rigidbody2D>();
   }
      
    
   public bool Shoot(bool shoot)
   {
    this._shoot = shoot;
    return _shoot;
   }
    private void Update()
    {
        _currentCD -= Time.deltaTime;
        Shooting(_currentLevel);
    }
   
    public virtual void GetHit(float dmg)
    {
        if(_amor > dmg) return;
        _childHP -= (dmg - _amor);
        if(_childHP <= 0) 
        {  
           this.gameObject.SetActive(false);
           
        }   
    }
    public bool isShooting(float radius)
    {  
        return Physics2D.OverlapCircle(this.transform.position, radius, _enemyCheck);
    }
    
    public void Shooting(int currentLevel)
    { this._currentLevel = currentLevel;
      if(_currentLevel == 1) return;
      if(_currentLevel == 2) ShootingLevel2();
      else if (_currentLevel == 3) ShootingLevel3();
    }
    private void ShootingLevel2()
    {

        if(_currentCD >=0 || isShooting(_lv2Radius)!= true) return;
        
        GameObject _bulletInstant2 = ObjectPooling.Instant.GetObj(_childBullet[0].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _lv2Radius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  Vector3 _direction =target.transform.position - this.transform.position;
           _bulletInstant2.GetComponent<BulletBase>().Init(_lv2Speed, _lv2Dmg, _lifeTime, _direction);
           _bulletInstant2.transform.position = this.transform.position;
           _bulletInstant2.SetActive(true);
           _currentCD = _lv2CD;
           
        }
    }
    private void ShootingLevel3()
    {
        
        if(_currentCD>=0 || isShooting(_lv3Radius)!= true) return;
        
        GameObject _bulletInstant3 = ObjectPooling.Instant.GetObj(_childBullet[1].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position,_lv3Radius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  Vector3 _direction =target.transform.position - this.transform.position;
           _bulletInstant3.GetComponent<BulletBase>().Init(_lv3Speed, _lv3Dmg, _lifeTime, _direction);
           _bulletInstant3.transform.position = this.transform.position;
           _bulletInstant3.SetActive(true);
           _currentCD = _lv3CD;
           
        }


    }

    private void OnDrawGizmosSelected() 
    {  

        Gizmos.DrawWireSphere(this.transform.position, _lv2Radius);
        Gizmos.DrawWireSphere(this.transform.position, _lv3Radius);

    }
    
    
}
