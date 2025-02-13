using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    [SerializeField] float _lifeTime;

   
    void Update()
    {
        Destroy(this.gameObject, _lifeTime);
        
    }

}
