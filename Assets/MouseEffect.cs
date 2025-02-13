using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour
{
    
    Animator _animator;

    private void Start()
    {
        if(_animator ==null)
        {
            _animator = this.GetComponent<Animator>();
        }
    }

    private void Update()
    {

        Vector3 _mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousPos.z =0f;

        this.transform.position = _mousPos;

        if(Input.GetMouseButton(0))
        {
            _animator.SetTrigger("isWatering");
        }else{
            _animator.SetTrigger("Nothing");
        }
    }
}
