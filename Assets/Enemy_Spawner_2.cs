using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner_2 : MonoBehaviour
{
      List<GameObject> _enemyPooling = new List<GameObject>();
    [SerializeField] float _currentCoolDownTime, _SpawningCoolDownTimePhase2;
    [SerializeField] EnemyBase _enemyBase; 

    GameManager _gameM;
    
    

    private void Start()
    {
        _gameM = GameManager.Instant;
        
    }
    private void Update()
    { 
                    _currentCoolDownTime -=Time.deltaTime;

        if(_gameM._currentState == State.Phase2)
        {
              Spawning();

        }
     

    }
   
    private void Spawning()
    {
        if(_currentCoolDownTime >= 0) return;
    
        GameObject _enemy= ObjectPooling.Instant.GetObj(_enemyBase.gameObject);
        _enemy.transform.position = this.transform.position;
        _enemy.transform.SetParent(this.transform);
        _enemy.SetActive(true);
        _currentCoolDownTime = _SpawningCoolDownTimePhase2;
    }
}
