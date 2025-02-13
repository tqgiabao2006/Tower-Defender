using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Corn_Button : MonoBehaviour
{

 [SerializeField] ButtonController[] _buttonController;
[SerializeField] GameObject _menuTab;
[SerializeField] int _index = 1;

private void OnEnable() {
   _buttonController = GetComponentsInParent<ButtonController>();
   
    
 }

  public void OnClick()
  {
    _buttonController[0].PickPlant(this.gameObject.name,_index);
    _menuTab.SetActive(false);

  }
}
