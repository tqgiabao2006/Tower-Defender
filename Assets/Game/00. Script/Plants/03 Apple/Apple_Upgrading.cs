using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Upgrading : MonoBehaviour
{
    
    [SerializeField] Shooting_Apple _shooting;
   GameManager GameM;
    BuyingSystem _buyingSystem;
    int _currentLevel = 1; 
[SerializeField] float _currentTime,_waitingTime;
   void Start()
   {
       GameM = GameManager.Instant;
       _buyingSystem = BuyingSystem.Instant;
       _shooting = this.GetComponent<Shooting_Apple>();
       
   }

   public void Update()
   {
    if( GameM._currentCoins< _buyingSystem._listPlants[2]._costLv2) return;

       if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Apple"))
            {
                _currentTime -= Time.deltaTime;

                
                      if(_currentLevel  == 1 && GameM._currentCoins >= _buyingSystem._listPlants[2]._costLv2 && _currentTime <=0 && _shooting._timesOfUpgradation_1_2 == 1)
                        {
                            _currentLevel  = 2;
                            GameM._currentCoins -=_buyingSystem._listPlants[2]._costLv2;
                            _currentTime = _waitingTime;
                            _shooting.ChangeAnimation(_currentLevel );
                            _shooting.Upgrading(_currentLevel );
                
                            
                        
                        }
                        if(_currentLevel   == 2 && GameM._currentCoins >= _buyingSystem._listPlants[2]._costLv3  && _currentTime<=0 && _shooting._timesOfUpgradation_2_3 == 1)
                        {
                           _currentLevel  = 3;
                            GameM._currentCoins -= _buyingSystem._listPlants[2]._costLv3;
                            _currentTime = _waitingTime;
                            _shooting.ChangeAnimation(_currentLevel );
                           _shooting.Upgrading(_currentLevel );
                
                        
                        }
                        
   

                }

            }

        }
    



  
    
}
