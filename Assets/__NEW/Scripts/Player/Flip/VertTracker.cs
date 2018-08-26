using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertTracker: MonoBehaviour 
{

    public Flip_Calc flip_Calc;

    public Transform[] vertices;
    public Transform localPlusZ;


    void Start()
    {
        
    }


    public bool isSwipeDirectionInZone(Vector3 userInputPosition, Transform vertex1, Transform vertex2)
    {

        float minAngle = flip_Calc.angleBetweenVerts(vertices[0].position, vertex1.position, localPlusZ.position);
        float maxAngle = flip_Calc.angleBetweenVerts(vertices[0].position, vertex2.position, localPlusZ.position);

        float swipeAngle = flip_Calc.angleBetweenVerts(userInputPosition, vertex2.position, localPlusZ.position);



        return flip_Calc.angleIsWithin(swipeAngle, minAngle, maxAngle);


    }





    // Select only outside angles, where angle < 180 degrees
    //void selectOutsideAngles()
    //{

    //    if (vertices_outside_only == null)
    //    {
    //        List<Transform> verts_temp;

    //        foreach (GameObject go in GameObject.FindGameObjectsWithTag("VertexOuter"))
    //        {
    //            verts_temp.Add(go.GetComponent<Transform>());
    //        }

    //    }

          


    //    for (int i = 1; i < vertices.Length; i++)
    //    {
    //        vertices_outside_only[i] =
    //    }
    //}



    // Angle zones represented by ordered float array, e.g. [0, 90, 180, 270] for square
    //void calculateAllAngleZones()
    //{

    //    angleZones = new float[vertices.Length];

    //    for (int i = 1; i < angleZones.Length; i++)
    //    {
    //        angleZones[i] = flip_Calc.angleBetweenVerts(vertices[0].position, vertices[i].position, localPlusZ.position);
    //    }
    //}

    //void assignAngleZonesToGhosts()
    //{

    //    angleZones = new float[vertices.Length];

    //    for (int i = 1; i < angleZones.Length; i++)
    //    {
    //        angleZones[i] = flip_Calc.angleBetweenVerts(vertices[0].position, vertices[i].position, localPlusZ.position);
    //    }
    //}




}
