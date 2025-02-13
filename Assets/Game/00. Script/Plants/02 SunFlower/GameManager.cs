using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{

    Phase0,
    Phase1,
    Phase2,

    BossPhase,
}
public class GameManager : MonoBehaviour
{
    private static GameManager _instant;
    public static GameManager Instant => _instant;
    public int _currentCoins;
    [SerializeField] public State _currentState = State.Phase0;
   

     [SerializeField]float _time;
    [SerializeField] float _timePhase1, _timePhase2, _timeBossPhase;

    public int _heart;

    private void Start()
    {        _currentState = State.Phase0;

    }
    private void Awake()
    {
        _instant = this;
    }

    public void UpdateCurrency()
    {

    }
    
    private void Update()
    {
        _time -= Time.deltaTime;

        if(_time < 0 && _currentState == State.Phase0)
        {
            _time = _timePhase1;
            _currentState = State.Phase1;
        }
       
        if(_time <0 && _currentState == State.Phase1)
        {  _time = _timePhase2;
            _currentState = State.Phase2;
          
        }
        if(_time < 0 && _currentState == State.Phase2)
        {
           _currentState = State.BossPhase;
           return;
        }
    }



}
