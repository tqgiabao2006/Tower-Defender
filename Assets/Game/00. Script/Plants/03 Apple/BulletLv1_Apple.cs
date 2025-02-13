using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLv1_Apple : BulletBase
{  Vector3 _enemyPos;
  Vector3 _topOfScreen ;
  private float _initialSpeed;
 [SerializeField] public float _waitingCD, _currentWaitingCd;


   protected override void Start()
   { if(rb == null)
     {     rb= this.GetComponent<Rigidbody2D>();

     }
        _topOfScreen = GetTopOfScreen();
       _currentWaitingCd = _waitingCD;

        _initialSpeed = _speed;

   }
    public override void Update()
    {
        Checking(_enemyPos);
         _lifeTime -= Time.deltaTime;
        if(_lifeTime <=0)
        {
            this.gameObject.SetActive(false);
        }
        if (_topOfScreen.y+1 < this.transform.position.y)
        {  _direction *= -1;

            this.transform.position = new Vector3(_enemyPos.x, this.transform.position.y, 0);
        }
        rb.velocity = _speed * _direction;

    }

    public void Checking(Vector3 enemyPos)
    { 
        this._enemyPos = enemyPos;

    }
    protected override void FixedUpdate()
    {
        // if (_topOfScreen.y+1 < this.transform.position.y)
        // {  _direction *= -1;

        //     this.transform.position = new Vector3(_enemyPos.x, this.transform.position.y, 0);
        // }
        // rb.velocity = _speed * _direction;


        
    }
    private Vector3 GetTopOfScreen()
    {
        Camera mainCamera = Camera.main;
        Vector3 topScreenPosition = new Vector3(Screen.width / 2f, Screen.height, 0);
        Vector3 topWorldPosition = mainCamera.ScreenToWorldPoint(topScreenPosition);
        topWorldPosition.z =0;
        return topWorldPosition;
    }    

    public override void Boom(GameObject target)
    {
        
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if(isCanGetHit != null)
        {
          isCanGetHit.GetHit(_dmg);
        this.gameObject.SetActive(false);


        }
    
    }
}
