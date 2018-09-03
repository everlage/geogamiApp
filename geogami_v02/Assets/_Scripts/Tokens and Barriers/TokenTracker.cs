using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenTracker : MonoBehaviour {

    bool levelComplete = false;
	
    void Update()
    {
        if (transform.childCount < 1 && !levelComplete)
        {
            levelComplete = true;


            Debug.Log("LEVEL COMPLETE!");
            // TODO
        }
    }
}
