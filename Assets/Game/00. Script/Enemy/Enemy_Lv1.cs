using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy_Lv1 : EnemyBase
{
   [SerializeField] float _radius;
   [SerializeField] LayerMask _plantCheck;
   Enemy_Animation _animationController;
   

   void Awake()
   {
    
    _animationController = this.GetComponentInChildren<Enemy_Animation>();
    _movePoints = GameObject.Find("MovePoints");

   }
    // private bool CheckingOutScreen()
    // {
    //     // Camera mainCamera = Camera.main;
    //     // Vector3 topScreenPosition = new Vector3(Screen.width / 2f, Screen.height, 0);
    //     // Vector3 topWorldPosition = mainCamera.ScreenToWorldPoint(topScreenPosition);
    //     // topWorldPosition.z =0;
    //     // if(this.transform.position.y >+ topWorldPosition.y + 2) return true;
    //     // else return false;
      
    // }
    
    public override void Doing()
    {
        // Vector3 _direction = this.transform.up;

        // if(CheckingOutScreen())
        // {  Vector3 _enemyPos = this.transform.position;
        //    Collider2D _plant = Physics2D.OverlapCircle(this.transform.position, _radius, _plantCheck);
        //     _enemyPos.x = _plant.transform.position.x;
        //     this.transform.position = _enemyPos;
        // }

    }

    public override void GetHitAnim()
    {
        _animationController.UpdateAnim();
    }








}
