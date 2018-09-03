using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier2 : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PlayerGhost"))
        {
         
            Ghost ghostScript = other.GetComponent<Ghost>();
            ghostScript.hitBarrier();

        }
    }
}
