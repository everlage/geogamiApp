using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

    TokenTracker myTracker;

    void Start()
    {
        myTracker = transform.parent.gameObject.GetComponent<TokenTracker>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            myTracker.collectToken(this);
        }
    }
}
