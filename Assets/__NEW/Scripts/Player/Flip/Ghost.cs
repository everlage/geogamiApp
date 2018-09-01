using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public AngleZone angleZoneScript;

    public bool legalMove;

    public void initialize()
    {

        checkIfThisGhostIsLegalMove();
    }


    public void checkIfThisGhostIsLegalMove()
    {

        // TODO

        if(true)
        {
            // This move is legal
            legalMove = true;
            angleZoneScript.enableZone();


        }
        else
        {
            //This move is illegal
            legalMove = false;
            angleZoneScript.disableZone();


        }

        updateMyMaterial();
    }


    public void updateMyMaterial()
    {
        // TODO
    }

    public void showIllegalFlipAnimation()
    {
        //TODO
    }


    public void prepareForFlip()
    {
        //TODO

        angleZoneScript.exitZone();
    }
}
