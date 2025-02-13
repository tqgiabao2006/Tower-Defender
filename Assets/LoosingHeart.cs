using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosingHeart : MonoBehaviour
{



   Collider2D _colli;
   GameManager _gameM;

   private void Start()
   {
    _colli = this.GetComponent<Collider2D>();
    _gameM = GameManager.Instant;
   }


    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.gameObject.CompareTag("Enemy"))
        {
        _gameM._heart --;
          other.gameObject.SetActive(false);
        }
    }
}
