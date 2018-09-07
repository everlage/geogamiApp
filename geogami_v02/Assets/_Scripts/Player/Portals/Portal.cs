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

        if (activePortal && other.gameObject.CompareTag("Vertex") && Mathf.Approximately(other.gameObject.GetComponent<Vert>().angle, myAngle) )
        {
            
            Flip_Manager flipManagerScript = other.transform.parent.parent.GetComponent<Flip_Manager>();
            flipManagerScript.enterPortal(gameObject, connectedPortals, other.gameObject);

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Vertex") && Mathf.Approximately(other.gameObject.GetComponent<Vert>().angle, myAngle) )
        {

            Flip_Manager flipManagerScript = other.GetComponent<Flip_Manager>();
            flipManagerScript.exitPortal(gameObject, connectedPortals);

        }
    }

}
