using System.Collections;
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

    public Vector3 mousePos;

    public void initializeAll()
    {
        foreach (GameObject go in angleZoneGOs)
        {
            //Debug.Log("foreach Loop");

            Ghost goScript = go.GetComponent<Ghost>();
            if(goScript)
            {
                goScript.initialize();
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

    public void startIllegalMoveAnimation()
    {
        
        angleZoneGOScript.startIllegalMoveAnimation();

    }
}
