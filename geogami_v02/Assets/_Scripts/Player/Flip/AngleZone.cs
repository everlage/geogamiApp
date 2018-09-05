using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleZone : MonoBehaviour {



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
        gameObject.GetComponent<MeshRenderer>().enabled = true; 
    }

    public void exitZone()
    {
        // TODO replace this with call to Ghost/Teleporter etc.
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }




    public bool isLegalMove()
    {
       


        Ghost ghost = gameObject.GetComponent<Ghost>();

        if (ghost != null)
        {
            return ghost.isLegalMove();
        }
        else
        {
            Debug.Log("ERROR: No ghost component found");
            //TODO implement for other game objects that could be angle zones
            return false;
        }


    }

    public void resetAngleZone()
    {



        Ghost ghost = gameObject.GetComponent<Ghost>();

        if (ghost != null)
        {
            ghost.resetBarrierDetection();
        }
        else
        {
            Debug.Log("ERROR: No ghost component found");
            //TODO implement for other game objects that could be angle zones

        }


    }

    public void startIllegalMoveAnimation()
    {
        
        Debug.Log("ILLEGAL MOVE");

        Ghost ghost = gameObject.GetComponent<Ghost>();
        ghost.runIllegalFlipAnimation();

    }



}
