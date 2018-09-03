using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSphere : Barrier {

    public float radius = .05f;
    public Color sphereColor;

    void OnDrawGizmos()
    {
        Gizmos.color = sphereColor;
        Gizmos.DrawSphere(transform.position, radius);
    }
   
}

