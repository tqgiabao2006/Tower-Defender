using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Tower
{
    public string _name;
    public int _costLv1, _costLv2, _costLv3;
    public GameObject _prefab;

    public Tower (string name, int costLv1, int costLv2, int costLv3 ,  GameObject prefab)
    {
        _name = name;
        _costLv1 = costLv1;
        _costLv3 = costLv3;
        _costLv2 = costLv2;
        _prefab = prefab;
    }

    
}
