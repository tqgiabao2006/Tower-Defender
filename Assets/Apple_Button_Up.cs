using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Apple_Button_Up : MonoBehaviour
{
    TextMeshPro _text;
    BuyingSystem _buyingSystem;
    [SerializeField] int _currentLevel;





  private void OnEnable() 
  {
    _currentLevel = 1;
    
   }
  
   void Update()
   {
       if(_currentLevel == 3) this.gameObject.SetActive(false);
   }
   
    private void Start()
    {
        _buyingSystem = BuyingSystem.Instant;
        _text = this.GetComponent<TextMeshPro>();

    }
    public void OnClick()
    {   //if(_currentLevel>3 || _buyingSystem.AppleUpgrading(_currentLevel)== false) return;
        _currentLevel ++;
        _buyingSystem.AppleUpgrading(_currentLevel);

    }
}
