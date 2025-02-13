using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose_Shooting : ShootingBase
{
 [SerializeField] List<BulletBase> _bullet = new List<BulletBase>();
 
    [Header("----------Level2 Config-------------")]
    [SerializeField] float _level2Radius;
    [SerializeField] float _level2CoolDownTime,_level2Dmg;
    
    [Header("--------Level3 Config--------")]
        [SerializeField] float _level3Radius;
    [SerializeField] float _level3CoolDownTime,  _level3Dmg;  

    [Header("--------Current Level-------")]
    [SerializeField] int _currentLevel;
    
 
   private void Update()
    {   _currentShootingTime -= Time.deltaTime;
        Shooting();
        CheckingLevel(_currentLevel);
        
    }
    public override void Shooting()
    {  
        
    }
  
    public void CheckingLevel(int currentLevel)
    {
        this._currentLevel = currentLevel;
        if(_currentLevel == 2) ShootingLevel2();
        else if(_currentLevel == 3) ShootingLevel3();
        else ShootingLevel1();

    }
    private void ShootingLevel1()
    {   isShooting(_basicRadius);
        if(_currentShootingTime >=0 || isShooting(_basicRadius)!= true) return;
        GameObject _bulletInstant = ObjectPooling.Instant.GetObj(_bullet[0].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _basicRadius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  _direction =target.transform.position - this.transform.position;
           _bulletInstant.GetComponent<BulletBase>().Init(_speed, _dmg, _lifeTime, _direction);
           _bulletInstant.transform.position = this.transform.position;
           _bulletInstant.SetActive(true);
           _currentShootingTime = _shootingCoolDown;
        }
    }
    private void ShootingLevel2()
    {
        isShooting(_level2Radius);

        if(_currentShootingTime >=0 || isShooting(_level2Radius)!= true) return;
        
        GameObject _bulletInstant2 = ObjectPooling.Instant.GetObj(_bullet[1].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _level2Radius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  _direction =target.transform.position - this.transform.position;
           _bulletInstant2.GetComponent<BulletBase>().Init(_speed, _level2Dmg, _lifeTime, _direction);
           _bulletInstant2.transform.position = this.transform.position;
           _bulletInstant2.SetActive(true);
          _currentShootingTime = _level2CoolDownTime;
           
        }
    }
    private void ShootingLevel3()
    {
        isShooting(_level3Radius);
        if(_currentShootingTime >=0 || isShooting(_level3Radius)!= true) return;
        
        GameObject _bulletInstant3 = ObjectPooling.Instant.GetObj(_bullet[1].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _level3Radius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  _direction =target.transform.position - this.transform.position;
           _bulletInstant3.GetComponent<BulletBase>().Init(_speed, _level3Dmg, _lifeTime, _direction);
           _bulletInstant3.transform.position = this.transform.position;
           _bulletInstant3.SetActive(true);
          _currentShootingTime = _level3CoolDownTime;
           
        }


    }

    private void OnDrawGizmosSelected() 
    {   Gizmos.DrawWireSphere(this.transform.position, _basicRadius);

        Gizmos.DrawWireSphere(this.transform.position, _level2Radius);
        Gizmos.DrawWireSphere(this.transform.position, _level3Radius);

    }
}
