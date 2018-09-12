using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTracker : MonoBehaviour {

    public List<Portal> myPortals;

    // Use this for initialization
    void Start () {

        foreach (Transform child in transform)
        {
            Portal childPortal = child.gameObject.GetComponent<Portal>();
            myPortals.Add(childPortal);
        }

        // Gather all portals
        // Group them by angles
        // Initialize all portals
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
