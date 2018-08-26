using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Manager : MonoBehaviour {

    public Flip_180 flip_180;
    public Flip_Input flip_Input;
    public Flip_Animation flip_Animation;
    public VertTracker vertTracker;

    public List<GameObject> angleZoneGOs; // Objects that include angle zone information (normally ghosts)
    public GameObject angleZoneGO;
    public AngleZone angleZoneGOScript;

    public Vector3 mousePos;

	void Update () {
        if (Input.anyKeyDown)
        {
            flip_Input.keyPressed();
        } 
        else if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouseClicked");
            mouseClicked();

        }
	}


    public void mouseMoved()
    {
       

        if( !stillInCurrentAngleZone() )
            updateCurrentAngleZone();



    }

    public void mouseClicked()
    {
        // TODO - Mouse Click when shape is selected
        Debug.Log("mouseClicked");


        updateCurrentAngleZone();

            
    }

    // Returns true if mouse is still in currently saved angle zone 
    public bool stillInCurrentAngleZone()
    {
        Debug.Log("stillInCurrentAngleZone" );

        // Get mouse position
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return vertTracker.isSwipeDirectionInZone(mousePosInWorld, angleZoneGOScript.vertMin, angleZoneGOScript.vertMax);
    }

    public void updateCurrentAngleZone()
    {
        Debug.Log("updateCurrentAngleZone");

        // Disable old angle zone
        angleZoneGOScript.exitZone();

        // Get mouse position
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Find new angle zone
        foreach (GameObject go in angleZoneGOs)
        {
            //TODO if zone is enabled and correct direction
            if(vertTracker.isSwipeDirectionInZone(mousePosInWorld, angleZoneGOScript.vertMin, angleZoneGOScript.vertMax))
            {
                angleZoneGO = go;
                angleZoneGOScript = angleZoneGO.GetComponent<AngleZone>();
                angleZoneGOScript.enterZone();
                break;
            }

        }



    }


    //public void attemptToFlip(Vector3 swipeDirection)
    //{
    //    Debug.Log("attemptToFlip: " + swipeDirection);


    //}
}
