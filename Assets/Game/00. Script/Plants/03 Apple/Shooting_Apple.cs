using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public enum AppleState
{
    Apple_Idle_1,
    Apple_Idle_2,
    Apple_Idle_3,

    Apple_Shooting_1,
     Apple_Shooting_2,
      Apple_Shooting_3,

      Apple_Upgrading_1_2,
      Apple_Upgrading_2_3,

}
public class Shooting_Apple : ShootingBase
{   [SerializeField] float _generalCD, _waitingCD;
    [SerializeField] int _numbOfBullet;
    [SerializeField] List<BulletBase> _bullet = new List<BulletBase>();
    [Header("----------Level2 Config-------------")]
    [SerializeField] float _level2Radius;
    [SerializeField] float _level2CoolDownTime,_level2Dmg;
    
    [Header("--------Level3 Config--------")]
        [SerializeField] float _level3Radius;
    [SerializeField] float _level3CoolDownTime,  _level3Dmg;  

    [Header("--------Current Level-------")]
    [SerializeField] int _currentLevel;
    [SerializeField] public AppleState _currentAppleState;
    Apple_Animation _animController;
    public int _timesOfUpgradation_1_2 = 1;
    public int _timesOfUpgradation_2_3 = 1;
    
    
 
  void Start()
  {
       _numbOfBullet = 0;
       _animController = this.GetComponentInChildren<Apple_Animation>();
  }
   private void Update()
    {   _currentShootingTime -= Time.deltaTime;
        Shooting();
        Upgrading(_currentLevel);
        EventTrigger();
        ChangeAnimation(_currentLevel);
        
    }
    public override void Shooting()
    {  
        
    }
    public void Upgrading(int currentLevel)
    {
      if(currentLevel == 1) return;

      if(currentLevel == 2 && _timesOfUpgradation_1_2 == 1)
      {
        _currentAppleState= AppleState.Apple_Upgrading_1_2;
        _animController.UpdateAnim(_currentAppleState);
        _timesOfUpgradation_1_2--;
       
  

      }
      if(currentLevel == 3 && _timesOfUpgradation_2_3 == 1)
      {
        _currentAppleState =  AppleState.Apple_Upgrading_2_3;
        
        _animController.UpdateAnim(_currentAppleState);
        _timesOfUpgradation_2_3--;
       
      }
    }
    
     private void EventTrigger()
    {
      _animController._eventAction += (nameEvent) =>
        {
          if(nameEvent == "Shooting_lv1" && isShooting(_basicRadius))
          {
            if(_currentShootingTime <=0)
            {
               ShootingLevel1();
               _currentShootingTime = _shootingCoolDown;
            }
          }
          if(nameEvent == "Shooting_lv2" && isShooting(_level2Radius))
          {
            if(_currentShootingTime<=0)
            {
              ShootingLevel2();
              _currentShootingTime = _level2CoolDownTime;
            }
          }

          if(nameEvent == "Shooting_lv3" && isShooting(_level3Radius))
          {
            if(_currentShootingTime <=0)
            {
               ShootingLevel3();
              _currentShootingTime = _level3CoolDownTime;

            }
          }
          if(nameEvent == "EndUpgrading_1_2")
          {
              _currentAppleState = AppleState.Apple_Idle_2;
            _animController.UpdateAnim(AppleState.Apple_Idle_2);
            
            
          }
          if(nameEvent == "EndUpgrading_2_3")
          {
            _currentAppleState= AppleState.Apple_Idle_3;
            _animController.UpdateAnim(AppleState.Apple_Idle_3);
            
          }

        };
    }
  
    public void ChangeAnimation(int currentLevel)
    {

      if(_currentAppleState == AppleState.Apple_Upgrading_1_2|| _currentAppleState == AppleState.Apple_Upgrading_2_3)
      {
        return;
      }

      if(currentLevel == 1)
      {
        if(isShooting(_basicRadius))
        {
          _currentAppleState= AppleState.Apple_Shooting_1;
        }else _currentAppleState = AppleState.Apple_Idle_1;
        _animController.UpdateAnim(_currentAppleState);
      }
       
      if(currentLevel == 2)
      {
         if(isShooting(_level2Radius))
         {
           _currentAppleState = AppleState.Apple_Shooting_2;
         }else _currentAppleState= AppleState.Apple_Idle_2;
        _animController.UpdateAnim(_currentAppleState);
      }
      if(currentLevel == 3)
      {
         if(isShooting(_level3Radius))
         {
           _currentAppleState= AppleState.Apple_Shooting_3;
         }else _currentAppleState = AppleState.Apple_Idle_3;
        _animController.UpdateAnim(_currentAppleState);

      }

    }

   
    private void ShootingLevel1()
    {   isShooting(_basicRadius);

        if(_currentShootingTime >=0 || isShooting(_basicRadius)!= true) return;
          GameObject _bulletInstant = ObjectPooling.Instant.GetObj(_bullet[0].gameObject); 

         Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _basicRadius,_enemyCheck);
         foreach(Collider2D target in targets)
        {  
           _bulletInstant.GetComponent<BulletBase>().Init(_speed, _dmg, _lifeTime, this.transform.up);
           _bulletInstant.transform.position = this.transform.position;
           _bulletInstant.SetActive(true);
           _bulletInstant.GetComponent<BulletLv1_Apple>().Checking(target.transform.position);
        }
          if(_numbOfBullet <2)
           {
            _currentShootingTime = _shootingCoolDown;
             _numbOfBullet++;
            

           }else if(_numbOfBullet >=2)
           {
            _currentShootingTime = _generalCD;
            _numbOfBullet = 0;

           }
       
        
         
       
        

        
    }
    private void ShootingLevel2()
    {
        isShooting(_level2Radius);

        if(_currentShootingTime >=0 || isShooting(_level2Radius)!= true) return;
        
        GameObject _bulletInstant2 = ObjectPooling.Instant.GetObj(_bullet[1].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _level2Radius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  _bulletInstant2.GetComponent<BulletBase>().Init(_speed, _dmg, _lifeTime, this.transform.up);
           _bulletInstant2.transform.position = this.transform.position;
           _bulletInstant2.SetActive(true);
           _bulletInstant2.GetComponent<BulletLv1_Apple>().Checking(target.transform.position);
           
        }
    }
    private void ShootingLevel3()
    {
        isShooting(_level3Radius);
        if(_currentShootingTime >=0 || isShooting(_level3Radius)!= true) return;
        
        GameObject _bulletInstant3 = ObjectPooling.Instant.GetObj(_bullet[2].gameObject); 
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _level3Radius,_enemyCheck);
        foreach(Collider2D target in targets)
        {  _bulletInstant3.GetComponent<BulletBase>().Init(_speed, _dmg, _lifeTime, this.transform.up);
           _bulletInstant3.transform.position = this.transform.position;
           _bulletInstant3.SetActive(true);
           _bulletInstant3.GetComponent<BulletLv1_Apple>().Checking(target.transform.position);
           
        }


    }

    private void OnDrawGizmosSelected() 
    {   Gizmos.DrawWireSphere(this.transform.position, _basicRadius);

        Gizmos.DrawWireSphere(this.transform.position, _level2Radius);
        Gizmos.DrawWireSphere(this.transform.position, _level3Radius);

    }


}
