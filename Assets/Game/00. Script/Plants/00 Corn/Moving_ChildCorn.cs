using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.AI;

public class Moving_ChildCorn : MonoBehaviour
{
  [SerializeField] GameObject _childCorn; 
   [SerializeField] float _spacing;
    private void OnEnable() 
    {
      
        SpawnObjects();
    
      
    }
    

    void SpawnObjects()
    {

       Vector3 spawnPosition = this.transform.position + Vector3.up * _spacing;
        Instantiate(_childCorn, spawnPosition, Quaternion.identity);

        // Spawn object below
        spawnPosition = this.transform.position - Vector3.up * _spacing;
        Instantiate(_childCorn, spawnPosition, Quaternion.identity);

        // Spawn object to the left
        spawnPosition = this.transform.position - Vector3.right * _spacing;
        Instantiate(_childCorn, spawnPosition, Quaternion.identity);

        // Spawn object to the right
        spawnPosition = this.transform.position + Vector3.right * _spacing;
        Instantiate(_childCorn, spawnPosition, Quaternion.identity);
    
        
    }
  

  

    
}



