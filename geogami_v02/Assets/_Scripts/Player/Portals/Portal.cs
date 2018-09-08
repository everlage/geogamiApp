using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {


    
    [Tooltip("Angle at portal point in degrees")]
    public float myAngle;

    public Transform vertexStart;
    public Transform vertexEnd;

    public List<GameObject> connectedPortals;

    public bool activePortal; // TODO


    void Start()
    {
        // TODO: Get all connected portals (same angle) and save in list
    }

    void OnTriggerEnter(Collider other)
    {
        if (activePortal && other.gameObject.CompareTag("Vertex") )
        {
            enterMyPortal(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vertex") )
        {
            exitMyPortal(other.gameObject);
        }
    }


    void enterMyPortal(GameObject vertex)
    {
        if (Mathf.Approximately(vertex.GetComponent<Vert>().angle, myAngle))
        {

            Flip_Manager flipManagerScript = vertex.transform.parent.parent.GetComponent<Flip_Manager>();
            flipManagerScript.enterPortal(gameObject, connectedPortals, vertex.gameObject);
        }
    }

    void exitMyPortal(GameObject vertex)
    {
        if(Mathf.Approximately(vertex.GetComponent<Vert>().angle, myAngle) )
        {
            Flip_Manager flipManagerScript = vertex.transform.parent.parent.GetComponent<Flip_Manager>();
            flipManagerScript.exitPortal(gameObject, connectedPortals);
        }

    }

    // TODO: Add listener, when states have changed, call enterMyPortal and exitMyPortal again to renew ghosts

}
