using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeTracker : MonoBehaviour {

    public List<PlayerShape> myPlayerShapes;

    // Use this for initialization
    void Start()
    {

        foreach (Transform child in transform)
        {
            if(child.CompareTag("Player"))
            {
                PlayerShape playerShape = child.gameObject.GetComponent<PlayerShape>();
                myPlayerShapes.Add(playerShape);
            }

        }


    }

    // Update is called once per frame
    public void updateTracker () 
    {
        foreach (PlayerShape ps in myPlayerShapes)
        {
            ps.updatePlayerShape();
        }
    }



}
