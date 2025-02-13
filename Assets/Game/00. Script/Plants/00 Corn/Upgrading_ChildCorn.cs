using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrading_ChildCorn : MonoBehaviour
{
        
   [SerializeField] Shooting_Corn _shooting;
   //[SerializeField] Shooting_Corn _shootingChild;
   [SerializeField] float _currentTime,_waitingTime;
      int _currentLevel =1 ;


   GameManager GameM;
   BuyingSystem _buyingSystem;

   void Start()
   {
       GameM = GameManager.Instant;
       _buyingSystem = BuyingSystem.Instant;
      
   }
    public void Update()
   {
    if( GameM._currentCoins< _buyingSystem._listPlants[0]._costLv2) return;

       if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Corn"))
            {    
                        _currentTime -= Time.deltaTime;
                      if(  _currentLevel == 1 && GameM._currentCoins >= _buyingSystem._listPlants[0]._costLv2 && _currentTime <=0 && _shooting._timesOfUpgradation_1_2 == 1)
                        {
                         
                             _currentLevel = 2;
                            GameM._currentCoins -=_buyingSystem._listPlants[0]._costLv2;
                            _currentTime = _waitingTime;
                            _shooting.ChangeAnimation( _currentLevel );
                            _shooting.Upgrading( _currentLevel );
                

                        
                        }
                        if( _currentLevel  == 2 && GameM._currentCoins >= _buyingSystem._listPlants[0]._costLv3  && _currentTime<=0 && _shooting._timesOfUpgradation_2_3 == 1)
                        {
                            _currentLevel   = 3;
                            GameM._currentCoins -= _buyingSystem._listPlants[0]._costLv3;
                            _currentTime = _waitingTime;
                            _shooting.ChangeAnimation( _currentLevel );
                           _shooting.Upgrading( _currentLevel );
                
                        
                        }
                        
   

                }

            }

        }


   }

