using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawning : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] int _childNumb;

   
    void OnEnable()
    {  
        for(int i =0 ; i < _childNumb; i++)
        {
            Instantiate(_enemy, this.transform.position, Quaternion.identity);
        
            
        }
        
    }
}
