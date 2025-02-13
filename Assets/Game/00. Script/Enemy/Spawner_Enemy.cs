using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
public class Spawner_Enemy : MonoBehaviour
{
    List<GameObject> _enemyPooling = new List<GameObject>();
    [SerializeField] float _currentCoolDownTime, _SpawningCoolDownTimePhase1, _SpawningCoolDownTimePhase2;

   [SerializeField] GameObject Boss;
    [SerializeField] EnemyBase _enemyBase; 

    GameManager _gameM;
    
    

    private void Start()
    {
        _gameM = GameManager.Instant;
    }
    private void Update()
    { 
        
        _currentCoolDownTime -=Time.deltaTime;

        if(_gameM._currentState == State.Phase1)
        {
            SpawningPhase1();
        }
          if(_gameM._currentState == State.Phase2)
        {
            SpawningPhase2();
        }

          if(_gameM._currentState == State.BossPhase)
        {

            Boss.SetActive(true);
            SpawningPhase1();
        }
        

    }
   
    private void SpawningPhase1()
    {
        if(_currentCoolDownTime >= 0) return;
    
        GameObject _enemy= ObjectPooling.Instant.GetObj(_enemyBase.gameObject);
        _enemy.transform.position = this.transform.position;
        _enemy.transform.SetParent(this.transform);
        _enemy.SetActive(true);
        _currentCoolDownTime = _SpawningCoolDownTimePhase1;
    }

    private void SpawningPhase2()
    { if(_currentCoolDownTime >= 0) return;
    
        GameObject _enemy= ObjectPooling.Instant.GetObj(_enemyBase.gameObject);
        _enemy.transform.position = this.transform.position;
        _enemy.transform.SetParent(this.transform);
        _enemy.SetActive(true);
        _currentCoolDownTime = _SpawningCoolDownTimePhase2;

    }
}
