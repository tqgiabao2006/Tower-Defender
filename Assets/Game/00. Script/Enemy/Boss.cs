using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public enum BossState
{
    Boss_GetHit,
    Boss_Running,
    Boss_Casting, 

}
public class Boss : EnemyBase
{

   [SerializeField] GameObject _enemy; 
   [SerializeField] float _spacing, _currentCD, _CD;
   [SerializeField] BossState _currentBossState;
   Boss_Animation _animController;
   private void Awake()
   {
     _animController = this.GetComponentInChildren<Boss_Animation>();
     _movePoints = GameObject.Find("MovePoints");

   }

  
    public override void Doing()
    {
       _currentCD -= Time.deltaTime;
       ChangeAnimation();
         EventTrigger();
       
      
       
    }

    private void Spawning()
    {
        Vector3 spawnPosition = this.transform.position + Vector3.up * _spacing;
        Instantiate(_enemy, spawnPosition, Quaternion.identity);

        // Spawn object below
        spawnPosition = this.transform.position - Vector3.up * _spacing;
        Instantiate(_enemy, spawnPosition, Quaternion.identity);

        // Spawn object to the left
        spawnPosition = this.transform.position - Vector3.right * _spacing;
        Instantiate(_enemy, spawnPosition, Quaternion.identity);

        // Spawn object to the right
        spawnPosition = this.transform.position + Vector3.right * _spacing;
        Instantiate(_enemy, spawnPosition, Quaternion.identity);
         
        
    }
    private void EventTrigger()
    { 

         _animController._eventAction += (nameEvent) =>
        {
            if(_currentCD <=0 && nameEvent == "Boss_Casting")
            {
                Spawning();
                _currentCD = _CD;
                _speed = 2;
                
            }
         
        };
    }
    private void ChangeAnimation()
    {
        if(_currentCD <= 0 && _speed >0)
        {
            _currentBossState =BossState.Boss_Casting;
            _speed = 0;
        }else if(_currentCD >0)
        {
            _currentBossState = BossState.Boss_Running;
            _speed = 2;
        }
        _animController.UpdateAnim(_currentBossState);
      
    }

    public override void GetHitAnim()
    {
        _currentBossState = BossState.Boss_GetHit;
        _animController.UpdateAnim(_currentBossState);

    }


}