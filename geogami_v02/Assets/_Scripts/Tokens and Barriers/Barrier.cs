﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Ghost"))
        {
         
            Ghost ghostScript = other.GetComponent<Ghost>();
            ghostScript.hitBarrier();

        }
    }
}
