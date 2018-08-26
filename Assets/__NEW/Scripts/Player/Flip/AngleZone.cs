using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleZone : MonoBehaviour {

    // Vertices associated with this ghost
    public Transform vertMin;
    public Transform vertMax;

    public bool zone_enabled = true;



    public void enterZone()
    {
        // TODO replace this with call to Ghost/Teleporter etc.
        gameObject.SetActive(true);
    }

    public void exitZone()
    {
        // TODO replace this with call to Ghost/Teleporter etc.
        gameObject.SetActive(false);
    }

}
