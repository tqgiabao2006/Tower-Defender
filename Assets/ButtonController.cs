using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
   

     private static ButtonController _instant;
   public static  ButtonController Instant => _instant;
  [SerializeField] public GameObject _upgradingMenu;
  public int _selectedTower = 0;
   void Awake()
   {
      _instant = this; 
   }
     [SerializeField] GameObject _menuBar;
     GameManager _gameM;
     Transform _place;

     private void Start()
     {
      _gameM = GameManager.Instant;
     }
    public void OpenMenu()
   {
     if(_menuBar.activeSelf == false)
     {
        _menuBar.SetActive(true);
     }
   }

   public void SelectPlace(Transform place)
   {
      this._place = place;
   }
   public void PickPlant(string name, int index)
   {       
    for(int i =0; i <=_gameM.GetComponent<BuyingSystem>().plants.Length-1; i++)
    {
      if(name == _gameM.GetComponent<BuyingSystem>().plants[i].name)
      {
        if(_gameM._currentCoins >= _gameM.GetComponent<BuyingSystem>()._listPlants[index]._costLv1)
        {
           _gameM._currentCoins -= _gameM.GetComponent<BuyingSystem>()._listPlants[index]._costLv1;
           GameObject newPlant = Instantiate(_gameM.GetComponent<BuyingSystem>().plants[i], this.transform.position, quaternion.identity);
          newPlant.transform.position = _place.transform.position;
                    _place.transform.GetComponent<Place_button>().gameObject.SetActive(false);
                   
        }else
        {
                
                   
          _place.transform.GetComponent<Place_button>().gameObject.SetActive(true);


        }
  
      }
    }
   }

   public void SelectedPlant(string name)
   {
     _upgradingMenu.transform.Find(name).gameObject.SetActive(true);
      
   }

   
}
