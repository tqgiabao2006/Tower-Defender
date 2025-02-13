using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Place_button : MonoBehaviour
{
    
    protected ButtonController[]_buttonController;
    protected bool _success;
   protected void Start()
   {
     _buttonController = GetComponentsInParent<ButtonController>();
   }
    
   
    public void OnClick()
    {  
        _buttonController[0].SelectPlace(this.transform);
        
       
    }
   
    
}
