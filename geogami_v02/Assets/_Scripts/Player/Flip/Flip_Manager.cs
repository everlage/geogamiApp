﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Manager : MonoBehaviour {

    public Flip_180 flip_180;
    public Flip_Input flip_Input;
    public Flip_Animation flip_Animation;
    public VertTracker vertTracker;

    // ---------- Angle Zones
    public List<GameObject> angleZoneGOs; // Objects that include angle zone information (normally ghosts)
    public GameObject angleZoneGO;
    public AngleZone angleZoneGOScript;
    // ----------

    public Material ghostMatLegal;
    public Material ghostMatNotLegal;

    public void initializeAll()
    {
        foreach (GameObject go in angleZoneGOs)
        {
            Ghost goScript = go.GetComponent<Ghost>();
            if(goScript)
            {
                goScript.initialize(ghostMatLegal, ghostMatNotLegal);
            }
        }
    }

	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouseClicked");
            mouseClicked();

        }
        else if (Input.anyKeyDown)
        {
            Debug.Log("anyKeyDown");
            flip_Input.keyPressed();
        }
        else if (Input.GetAxis("Mouse X") > Mathf.Epsilon || Input.GetAxis("Mouse X") < -Mathf.Epsilon || Input.GetAxis("Mouse Y") > Mathf.Epsilon || Input.GetAxis("Mouse Y") < -Mathf.Epsilon)
        {
            mouseMoved();
        }

	}


    public void mouseMoved()
    {
       
        updateCurrentAngleZone();

        //Debug.Log("stillInCurrentAngleZone? " + stillInCurrentAngleZone());
        if( !stillInCurrentAngleZone() )
            updateCurrentAngleZone();



    }

    public void mouseClicked()
    {
        // Mouse Click when shape is selected
        updateCurrentAngleZone();

        if (angleZoneGOScript.isLegalMove())
        {
            moveShapeToCurrentGhost();
        }
        else
        {
            startIllegalMoveAnimation();
        }
    }

    // Returns true if mouse is still in currently saved angle zone 
    public bool stillInCurrentAngleZone()
    {
        

        // Get mouse position
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log("vertTracker " + vertTracker);
        //Debug.Log("angleZoneGOScript" + angleZoneGOScript);
        //Debug.Log("mousePosInWorld" + mousePosInWorld);
        //Debug.Log("vertMin" + angleZoneGOScript.vertMin);
        //Debug.Log("vertMax" + angleZoneGOScript.vertMax);
        //Debug.Log("stillInCurrentAngleZone? " + vertTracker.isSwipeDirectionInZone(mousePosInWorld, angleZoneGOScript.vertMin, angleZoneGOScript.vertMax) );

        return vertTracker.isSwipeDirectionInZone(mousePosInWorld, angleZoneGOScript.vertMin, angleZoneGOScript.vertMax);
    }

    public void updateCurrentAngleZone()
    {
        //Debug.Log("updateCurrentAngleZone");



        // Disable old angle zone
        if (angleZoneGOScript != null)
        {
            //Debug.Log("Old angleZoneGO; " + angleZoneGO);
            angleZoneGOScript.exitZone();
        }
        
        // Get mouse position
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Find new angle zone
        foreach (GameObject go in angleZoneGOs)
        {
            //Debug.Log("foreach Loop");

            AngleZone goScript = go.GetComponent<AngleZone>();

            //TODO if zone is enabled and correct direction
            if(vertTracker.isSwipeDirectionInZone(mousePosInWorld, goScript.vertMin, goScript.vertMax))
            {
                //Debug.Log("Found new angleZone!");
                angleZoneGO = go;
                angleZoneGOScript = angleZoneGO.GetComponent<AngleZone>();
                angleZoneGOScript.enterZone();

                //Debug.Log("================================= ");
                //Debug.Log("NEW angleZoneGO; " + angleZoneGO);
                break;
            }

        }



    }


    public void moveShapeToCurrentGhost()
    {
        
        angleZoneGOScript.exitZone();
        // TODO FLIP SHAPE

        flip_Animation.flipShape(angleZoneGO );
                      

    }

    public void flipCompleted()
    {
        foreach (GameObject go in angleZoneGOs)
        {
            AngleZone goScript = go.GetComponent<AngleZone>();
            if (goScript)
            {
                goScript.resetAngleZone();
            }
        }
    }

    public void startIllegalMoveAnimation()
    {
        
        angleZoneGOScript.startIllegalMoveAnimation();

    }


    //-------------
    // Portals
    //-------------

    public void enterPortal(GameObject portal, List<GameObject> connectedPortals, GameObject vertexTouchingPortal)
    {
        //TEMP
        translateToPortal(vertexTouchingPortal, connectedPortals[0]);
    }

    public void exitPortal(GameObject portal, List<GameObject> connectedPortals)
    {
        
    }

    public void translateToPortal(GameObject vertex, GameObject portal)
    {

        // TODO

        // ROTATE SO THAT angles are lined up with portal

        // Look at of the vertex's "adjacent verts", select the correct one that corresponds to min angle CCW (to match with portal's minVert angle)
        // Perhaps use plusZ to tell orientation, and convention for which vert is first?

        if(vertTracker.localPlusZ.position.z > 0)
        {
            //vertex.getAdjacent(1);
        }
        else
        {
            //vertex.getAdjacent(-1);
        }

        // Compare angle (using GLOBAL RIGHT) between vertex / adjacent vert and portal / minVert
        // Rotate shape around axis defined by vertex.


        // TRANSLATE so that vertex transform is at portal transform


    }

}
