using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.PlayerLoop;


public enum PlayerState
{
    SunF_Idle_1,
    SunF_Idle_2,
    SunF_Idle_3,


     Shooting_1,
    Shooting_2,

    Shooting_3, 

    Upgrading_1_2,
    Upgrading_2_3,
}

   
public class Shooting_Sunflower : ShootingBase
{
   [SerializeField] PlayerState _currentPlayerState;
    AnimationController _animController;
    [SerializeField] List<BulletBase> _bullet = new List<BulletBase>();
    [Header("----------Level2 Config-------------")]
    [SerializeField] float _level2Radius;
    [SerializeField] float _level2CoolDownTime,_level2Dmg;
    
    [Header("--------Level3 Config--------")]
    [SerializeField] float _level3Radius;
    [SerializeField] float _level3CoolDownTime,  _level3Dmg;  

    [Header("--------Current Level-------")]
    [SerializeField] int _currentLevel;

      public int _timesOfUpgradation_1_2 = 1;
    public int _timesOfUpgradation_2_3 = 1;
   
    
 
 private void Start() 
 {
    _animController = this.GetComponentInChildren<AnimationController>();
 }
   private void Update()
    {   _currentShootingTime -= Time.deltaTime;
        Upgrading(_currentLevel);
        ChangeAnimation(_currentLevel);
        EventTrigger();
        
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
              _currentPlayerState = PlayerState.SunF_Idle_2;
              _animController.UpdateAnim(PlayerState.SunF_Idle_2);
            
            
          }
          if(nameEvent == "EndUpgrading_2_3")
          {
            _currentPlayerState = PlayerState.SunF_Idle_3;
            _animController.UpdateAnim(PlayerState.SunF_Idle_3);
            
          }

        };
    }
    public override void Shooting()
    {  
    }

    public void ChangeAnimation(int currentLevel)
    {

      if(_currentPlayerState == PlayerState.Upgrading_1_2 || _currentPlayerState == PlayerState.Upgrading_2_3)
      {
        return;
      }

      if(currentLevel == 1)
      {
        if(isShooting(_basicRadius))
        {
          _currentPlayerState = PlayerState.Shooting_1;
        }else _currentPlayerState = PlayerState.SunF_Idle_1;

        _animController.UpdateAnim(_currentPlayerState);
      }
       
      if(currentLevel == 2)
      {
         if(isShooting(_level2Radius))
         {
           _currentPlayerState = PlayerState.Shooting_2;
         }else _currentPlayerState = PlayerState.SunF_Idle_2;
        _animController.UpdateAnim(_currentPlayerState);
      }
      if(currentLevel == 3)
      {
         if(isShooting(_level3Radius))
         {
           _currentPlayerState = PlayerState.Shooting_3;
         }else _currentPlayerState = PlayerState.SunF_Idle_3;
        _animController.UpdateAnim(_currentPlayerState);

      }

    }
    
    public void Upgrading(int currentLevel)
    {
      if(currentLevel == 1) return;

      if(currentLevel == 2 && _timesOfUpgradation_1_2 == 1)
      {
        _currentPlayerState = PlayerState.Upgrading_1_2;
        _animController.UpdateAnim(_currentPlayerState);
        _timesOfUpgradation_1_2--;
       
  

      }
      if(currentLevel == 3 && _timesOfUpgradation_2_3 == 1)
      {
        _currentPlayerState = PlayerState.Upgrading_2_3;
        
        _animController.UpdateAnim(_currentPlayerState);
        _timesOfUpgradation_2_3--;
       
      }
    }
    

    private void ShootingLevel1()
    {   
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
        GameObject _bulletInstant3 = ObjectPooling.Instant.GetObj(_bullet[2].gameObject); 
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
