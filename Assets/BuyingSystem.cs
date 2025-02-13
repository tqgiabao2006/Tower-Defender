using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class BuyingSystem : MonoBehaviour
{



  GameManager _gameM;
    private static BuyingSystem _instant;
   public static  BuyingSystem Instant => _instant;

   public int _appleLevel = 1;
   public int _cornLevel = 1;
   public int _sunfLevel = 1;

  [SerializeField] public GameObject[] plants;
  [SerializeField] public Tower[] _listPlants;
  [SerializeField] 


   void Awake()
   {
      _instant = this; 
      _gameM = GameManager.Instant;
   }

   public void AppleUpgrading(int currentLevel)
   {

      if(currentLevel == 2)
      {
         if(_gameM._currentCoins >= _listPlants[2]._costLv2)
         {
            _gameM._currentCoins -= _listPlants[2]._costLv2;
          

         }


      }

      if(currentLevel == 3)
      {
         if(_gameM._currentCoins >= _listPlants[2]._costLv3)
         {
            _gameM._currentCoins -=_listPlants[2]._costLv3;
            
         }

      }
       
   }


}
    
   





  




