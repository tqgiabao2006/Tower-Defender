using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints_Manager : MonoBehaviour
{

   public Transform[] movePoints;
   public void Start()
   {
    movePoints = GetComponentsInChildren<Transform>();
    
    
   }
   
   
}
