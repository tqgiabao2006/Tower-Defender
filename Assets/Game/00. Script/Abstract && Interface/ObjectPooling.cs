using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
   private static ObjectPooling _instant;
   public static ObjectPooling Instant => _instant;

   Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();

   void Awake()
   {
      _instant = this; 
   }
   public virtual GameObject GetObj(GameObject prefabs)
   { 
      List<GameObject> listObj = new List<GameObject>();
     if(_pool.ContainsKey(prefabs))
        listObj = _pool[prefabs];

      else
      {
         _pool.Add(prefabs, listObj);
      }
       
      foreach(GameObject g in listObj)
      {
         if(g.activeSelf)
         continue;
         return g;
      }
      GameObject g2 = Instantiate(prefabs, this.transform.position, Quaternion.identity);
      listObj.Add(g2);
      return g2;
   }
}
