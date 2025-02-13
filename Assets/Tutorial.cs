using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{


    [SerializeField] GameObject _tutorial;


    public void OnClick()
    {

        if(_tutorial.activeSelf == false)
        {
            _tutorial.SetActive(true);

        }else{
            _tutorial.SetActive(false);
        }



    }
}
