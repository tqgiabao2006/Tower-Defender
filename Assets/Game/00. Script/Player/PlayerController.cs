using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public enum ArcherState 
{
  Player_Idle,
  Player_Shooting,
  Player_Holding,
  Player_Run,

}
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed,_maxLifeTime, _shootingSpeed, _dmg, _currentLifeTime, _distance, _currentCD, _CD;
    
   [SerializeField] ArcherState _currentArcherState;
   LineRenderer _lineRenderer;

    Rigidbody2D rb;
    UnityEngine.Vector3 _movement = UnityEngine.Vector3.zero;
   [SerializeField] GameObject _shooting;
   [SerializeField] BulletBase _bullet;
   
   Player_Animation _animationController;
    UnityEngine.Vector3 _shootingDir;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        _animationController = this.GetComponentInChildren<Player_Animation>();
        _lineRenderer = this.GetComponentInChildren<LineRenderer>();
        _currentCD = _CD;
    }

    private void Update()
    {
           Moving();
           Shooting();
           EventTrigger();
           ChangeAnimation();
           

    }

    private void EventTrigger()
    {
        _animationController._eventAction += (nameEvent) =>
        {

            if(nameEvent == "Holding")
            {
                _currentArcherState = ArcherState.Player_Holding;
                _animationController.Holding(_currentArcherState);
            }



        };

    }
    private void FixedUpdate() 
    {
        rb.velocity = _movement * _speed;     
    }

    private void Moving()
    {
        if(_currentArcherState == ArcherState.Player_Shooting || _currentArcherState == ArcherState.Player_Holding) return;
       _movement.x = Input.GetAxisRaw("Horizontal");
       _movement.y = Input.GetAxisRaw("Vertical");
       

       if(_movement.x <0)
       {
         this.transform.localScale = new UnityEngine.Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
         
       }else if(_movement.x >0)
       {
          this.transform.localScale = new UnityEngine.Vector3(-1, this.transform.localScale.y, this.transform.localScale.z );
        
       }
    }

    private void ChangeAnimation()
    {
        if(_currentArcherState == ArcherState.Player_Holding) return;
        if(_movement.x != 0 || _movement.y !=0 )
       {
        _currentArcherState = ArcherState.Player_Run;
         _animationController.UpdateAnim(_currentArcherState);
       }else if (Input.GetKey(KeyCode.Q))
       {
            
         _currentArcherState = ArcherState.Player_Shooting;
        _animationController.UpdateAnim(_currentArcherState);
       }
       else 
       {
        _currentArcherState = ArcherState.Player_Idle;
        _animationController.UpdateAnim(_currentArcherState);

       }


    }

    private void Shooting()
    { 
        _shootingDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float _angle = Mathf.Atan2(_shootingDir.y, _shootingDir.x) * Mathf.Rad2Deg;
        UnityEngine.Vector3 _direction = _shootingDir - this.transform.position;
        _shooting.transform.rotation = UnityEngine.Quaternion.Euler(0f,0f, _angle);
        if(Input.GetKey(KeyCode.Q))
        {  _currentCD -= Time.deltaTime;

             if(_currentLifeTime < _maxLifeTime)
            {
                _currentLifeTime += Time.deltaTime;
            
               
            } 
            AimLine();

             
        }else if(Input.GetKeyUp(KeyCode.Q))
        {
            if(_currentCD <=0)
            {
                 GameObject _bulletInstant = ObjectPooling.Instant.GetObj(_bullet.gameObject); 
              _bulletInstant.GetComponent<BulletBase>().Init(_shootingSpeed, _dmg, _currentLifeTime, _shooting.transform.right);
              _bulletInstant.transform.position = this.transform.position;
           _bulletInstant.SetActive(true);
           _currentCD = _CD;
           _currentArcherState = ArcherState.Player_Idle;
           _animationController.Holding(_currentArcherState);
           EndLine();

            }else 
            {
                _currentCD = _CD;
            }
           
        }

        
    }

    private void AimLine()
    {
       _lineRenderer.SetPosition(0, this.transform.position);
       _lineRenderer.SetPosition(1, _shooting.transform.right * _distance);

    }
    private void EndLine()
    {
        _lineRenderer.SetPosition(0,this.transform.position);
       _lineRenderer.SetPosition(1, this.transform.position);

        
    }
        

}


