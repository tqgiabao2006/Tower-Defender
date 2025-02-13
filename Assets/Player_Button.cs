using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Button : Place_button
{
 

   [SerializeField] ButtonController[] _buttonController;
   [SerializeField] GameObject _menuTab;
   [SerializeField] int _index = 3; int _limit =0;



private void OnEnable() {
   _buttonController = GetComponentsInParent<ButtonController>();
    
 }

  public void OnClick()
  {
    if(_limit == 0)
    {
         _buttonController[0].PickPlant(this.gameObject.name, _index );
    }
    _menuTab.SetActive(false);
    _limit++;

  }
}


