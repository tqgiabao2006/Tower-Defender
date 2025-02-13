using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser_SunF : MonoBehaviour
{
    [SerializeField] float _radiusLv1, _radiusLv2, _radiusLv3;
    [SerializeField] float _dmgLv1, _dmgLv2, _dmgLv3, _currentTime, _CDTime;
    [SerializeField] LayerMask _enemyCheck1;
   [SerializeField] LineRenderer _lineRender;

  private void Start()
  {
    _lineRender = this.GetComponentInChildren<LineRenderer>();
  }
    
  private void Update()
   {
    _currentTime -= Time.deltaTime;
    ShootingLv1();
   }
   


   private bool isShooting(float _radius)
   {
     return Physics2D.OverlapCircle(this.transform.position, _radius, _enemyCheck1);

   }

   private void ShootingLv1()
   { 
     if(isShooting(_radiusLv1) != true) return;
     Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, _radiusLv1, _enemyCheck1);
     foreach(Collider2D target in targets)
      {  if(target.gameObject.activeSelf == false)
         {
                continue;
        }
        
        Debug.DrawRay(this.transform.position, target.transform.position - this.transform.position, Color.red );
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, target.transform.position - this.transform.position, Vector2.Distance(this.transform.position, target.transform.position)
        , _enemyCheck1);
        Draw2DRay(this.transform.position, hit.point);

       IGetHit isCanGetHit = target.GetComponent<IGetHit>();
       if(isCanGetHit != null)
       {
           if(_currentTime <=0 )
           {
            isCanGetHit.GetHit(_dmgLv1);
            _currentTime = _CDTime;

           }
            


       }
        

        
     }


   }

   private void Draw2DRay(Vector3 startPos, Vector3 endPos)
   {
    _lineRender.SetPosition(0, startPos);
    _lineRender.SetPosition(1, endPos); 
    

   }
   private void OnDrawGizmosSelected()
   {
     

 
     Gizmos.DrawWireSphere(this.transform.position, _radiusLv1);
    
   }
   
}
