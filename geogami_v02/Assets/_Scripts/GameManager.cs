using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // ---------- Player Shapes
    public List<GameObject> playerShapeGOs; // Objects that include angle zone information (normally ghosts)
    public GameObject selectedPlayerShapeGO;
    public Flip_Manager selectedPlayerShapeFMScript;
    // ----------

    // ---------- Tokens
    public List<GameObject> tokenGOs; 
    // ----------

    // ---------- Barriers
    public List<GameObject> barrierGOs; 
    // ----------

    // ---------- Canvas
    public List<GameObject> paintGOs; 
    // ----------


	// Use this for initialization
	void Start () {
        initializeAll();
	}
	
	// Update is called once per frame
	void Update () {
        updateAll();
	}


    public void initializeAll()
    {
        foreach (GameObject go in playerShapeGOs)
        {
            go.GetComponent<Flip_Manager>().initializeAll();
        }
    }

    public void updateAll()
    {
        
    }


}
