using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour, IGetHit
{
    [SerializeField] protected float _HP, _amor;
    [SerializeField] protected int _coinsDrop;
    protected Rigidbody2D rb;
    GameManager gameManager;
     [SerializeField] protected float _speed;
   
  public int _currentPoint;
   protected GameObject _movePoints;
   MovePoints_Manager _movePointsManager;

    public virtual void Start() 
    { 

        
        
        if(rb == null)
       {
        rb = this.GetComponent<Rigidbody2D>();
       }

        gameManager = GameManager.Instant;
         _movePointsManager = _movePoints.GetComponent<MovePoints_Manager>();
         _currentPoint = 1;

    }

    protected private void OnEnable() {
        _currentPoint = 1;
    }
    float dmg;

    public void GetHit(float dmg)
    {

        if(_amor > dmg) return;
        _HP -= (dmg - _amor);
        if(_HP <= 0) 
        {  
           this.gameObject.SetActive(false);
           gameManager._currentCoins +=  _coinsDrop;
           _currentPoint = 1;
        }  
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        GetHit(dmg);

        if(other.gameObject.CompareTag("Enemy") ==false)
        {
          GetHitAnim();

        }  
    }

 
    public void Init(float speedDecrease)
    { 
      this._speed -= speedDecrease;


    }
    public virtual void Update()
    {   
        Moving();
        Doing();
    }

   
    protected void Moving()
    {
       this.transform.position = Vector2.MoveTowards(this.transform.position, _movePointsManager.movePoints[_currentPoint].position,_speed * Time.deltaTime );

       if(Vector2.Distance(this.transform.position, _movePointsManager.movePoints[_currentPoint].position) <=0.5f)
       {
        if(_currentPoint < _movePointsManager.movePoints.Length-1)
        {
            _currentPoint++;
    

        }else return;

        if(_currentPoint == _movePointsManager.movePoints.Length)
        {
            _currentPoint = 1;
        
        }
       }
       
        
    }
   public abstract void GetHitAnim();
    public abstract void Doing();
}




