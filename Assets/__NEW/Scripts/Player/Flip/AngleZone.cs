using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleZone : MonoBehaviour {

    public Ghost ghostScript;

    // Vertices associated with this ghost
    public Transform vertMin;
    public Transform vertMax;

    // This is an on/off switch for disabling a zone under special circumstances, e.g. teleportation
    public bool zone_enabled = true;

    public void enableZone()
    {
        zone_enabled = true;
    }

    public void disableZone()
    {
        zone_enabled = false;
    }



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




    public bool isLegalMove()
    {
        return ghostScript.legalMove;

    }

    public void startIllegalMoveAnimation()
    {
        // TODO

        Debug.Log("ILLEGAL MOVE");

    }



}
