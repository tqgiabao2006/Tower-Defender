using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{

    public float _radius;
    public LayerMask _l;

    private void Update()
    {

      bool _x = Physics2D.OverlapCircle(this.transform.position, _radius, _l );
      print(_x);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, _radius);

    }




}
