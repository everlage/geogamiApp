using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTracker : MonoBehaviour {

    public List<Barrier> myBarriers;

    void Start () {
        foreach (Transform child in transform)
        {
            Barrier childBarrier = child.gameObject.GetComponent<Barrier>();
            myBarriers.Add(childBarrier);
        }
    }
	
	
}
