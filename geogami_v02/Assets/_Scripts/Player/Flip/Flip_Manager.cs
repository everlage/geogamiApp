using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Manager : MonoBehaviour
{

    public Flip_180 flip_180;
    public Flip_Input flip_Input;
    public Flip_Animation flip_Animation;
    public VertTracker vertTracker;


    // ---------- Angle Zones
    public List<AngleZone> myAngleZones; // Objects that include angle zone information (normally ghosts)
    public AngleZone currentAngleZone;
    // ----------

    public Material ghostMatLegal;
    public Material ghostMatNotLegal;

    #region Initialize

    public void initializeAll()
    {
        foreach (AngleZone az in myAngleZones)
        {
            if (az.gameObject.CompareTag("Ghost"))
            {
                Ghost ghost = az.gameObject.GetComponent<Ghost>();
                ghost.initialize(ghostMatLegal, ghostMatNotLegal);
            }
        }
    }

    #endregion


    #region Update

    public void updateFlipManager()
    {

        if (Input.GetMouseButtonDown(0))
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

    #endregion


    #region Angle Zones

    public void mouseMoved()
    {

        updateCurrentAngleZone();

        //Debug.Log("stillInCurrentAngleZone? " + stillInCurrentAngleZone());
        if (!stillInCurrentAngleZone())
            updateCurrentAngleZone();



    }

    public void mouseClicked()
    {
        // Mouse Click when shape is selected
        updateCurrentAngleZone();

        if (currentAngleZone.isLegalMove())
        {
            moveShapeToCurrentAngleZone();
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
        //Debug.Log("currentAngleZone" + currentAngleZone);
        //Debug.Log("mousePosInWorld" + mousePosInWorld);
        //Debug.Log("vertMin" + currentAngleZone.vertMin);
        //Debug.Log("vertMax" + currentAngleZone.vertMax);
        //Debug.Log("stillInCurrentAngleZone? " + vertTracker.isSwipeDirectionInZone(mousePosInWorld, currentAngleZone.vertMin, currentAngleZone.vertMax) );

        return vertTracker.isSwipeDirectionInZone(mousePosInWorld, currentAngleZone.vertMin, currentAngleZone.vertMax);
    }

    public void updateCurrentAngleZone()
    {

        // Disable old angle zone
        if (currentAngleZone != null)
        {
            currentAngleZone.exitZone();
        }

        // Get mouse position
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Find new angle zone
        foreach (AngleZone az in myAngleZones)
        {

            //TODO if zone is enabled and correct direction
            if (vertTracker.isSwipeDirectionInZone(mousePosInWorld, az.vertMin, az.vertMax))
            {
                currentAngleZone = az;
                currentAngleZone.enterZone();
                break;
            }

        }



    }


    public void moveShapeToCurrentAngleZone()
    {

        currentAngleZone.exitZone();
        // TODO FLIP SHAPE

        flip_Animation.flipShape(currentAngleZone);


    }

    public void flipCompleted()
    {
        foreach (AngleZone az in myAngleZones)
        {
            az.resetAngleZone();

        }
    }

    #endregion


    #region Animation

    public void startIllegalMoveAnimation()
    {

        currentAngleZone.startIllegalMoveAnimation();

    }

    public void startTranslateMoveAnimation()
    {

        currentAngleZone.startIllegalMoveAnimation();

    }

    #endregion


    #region Portals

    public void enterPortal(GameObject portal, List<GameObject> connectedPortals, GameObject vertexTouchingPortal)
    {
        //TEMP
        if (connectedPortals.Count > 1)
        {
            print("Too many portals");
        }
        else if (connectedPortals[0])
        {
            translateToPortal(vertexTouchingPortal, connectedPortals[0]);
        }

    }

    public void exitPortal(GameObject portal, List<GameObject> connectedPortals)
    {

    }

    public void translateToPortal(GameObject vertex, GameObject portal)
    {

        Vert vertScript = vertex.GetComponent<Vert>();
        Transform adjacentVert;

        Portal portalScript = portal.GetComponent<Portal>();


        // ------
        // ROTATE SO THAT angles are lined up with portal

        // Look at of the vertex's "adjacent verts", select the correct one that corresponds to min angle CCW (to match with portal's minVert angle)
        if (vertTracker.localPlusZ.position.z > 0)
        {
            //vertex.getAdjacent(1);
            adjacentVert = vertScript.adjacentVerts[0];

        }
        else
        {
            //vertex.getAdjacent(-1);
            adjacentVert = vertScript.adjacentVerts[1];
        }

        // Compare angle (using GLOBAL RIGHT) between vertex / adjacent vert and portal / minVert
        Vector3 directionToAdjVert = adjacentVert.position - vertex.transform.position;
        directionToAdjVert.z = 0;
        float angleToAdjVert = Vector3.Angle(directionToAdjVert, Vector3.right);

        Vector3 directionToPortalVertStart = portalScript.vertexStart.position - portal.transform.position;
        directionToPortalVertStart.z = 0;
        float angleToPortVert = Vector3.Angle(directionToPortalVertStart, Vector3.right);

        // Rotate shape around axis defined by vertex.

        transform.RotateAround(vertex.transform.position, Vector3.back, (angleToPortVert - angleToAdjVert));


        // ------
        // TRANSLATE so that vertex transform is at portal transform


        transform.Translate(portal.transform.position - vertex.transform.position, Space.World);

    }

    #endregion


}
