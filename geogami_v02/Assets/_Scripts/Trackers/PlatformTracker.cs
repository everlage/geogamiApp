using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTracker : MonoBehaviour {

    public List<Platform> myPlatforms;

    void Start()
    {
        foreach (Transform child in transform)
        {
            Platform childPlatform = child.gameObject.GetComponent<Platform>();
            myPlatforms.Add(childPlatform);
        }
    }
}
