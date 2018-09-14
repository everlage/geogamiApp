using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

    TokenTracker myTracker;

    public void setTracker(TokenTracker tracker)
    {
        myTracker = tracker;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            myTracker.collectToken(this);
        }
    }
}
