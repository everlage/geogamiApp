using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Inspector variables

    // ---------- Level Info
    public GameObject levelInfo;

    // ---------- Player Shapes
    public List<GameObject> playerShapeGOs; // Objects that include angle zone information (normally ghosts)
    public Transform shapeTracker;
    public ShapeTracker shapeTrackerScript;
    public GameObject selectedPlayerShapeGO;
    public Flip_Manager selectedPlayerShapeFMScript;

    // ---------- Tokens
    public TokenTracker tokenTracker;

    // ---------- Barriers
    public List<GameObject> barrierGOs; 
    public Transform barrierTracker;
    public BarrierTracker barrierTrackerScript;

    // ---------- Portals
    public List<GameObject> portalGOs;
    public Transform portalTracker;
    public PortalTracker portalTrackerScript;

    // ---------- Platforms
    public List<GameObject> platformGOs; 
    public Transform platformTracker;
    public PlatformTracker platformTrackerScript;

    #endregion

    #region Game Status variables


    bool animationRunning;


    #endregion

    // Use this for initialization
    void Start () {
        //initializeGameCore();
        initializeLevelStructure();
        initializeAllLevelObjects();
	}
	
	// Update is called once per frame
	void Update () {
        mainGameLoop();
	}


    #region Initialize

    public void initializeGameCore()
    {

       // TODO
    }

    public void initializeLevelStructure()
    {
        Transform level = GameObject.Find("Level").transform;

        Transform info = level.Find("Level Info");
        Transform shapes = level.Find("Shapes");
        Transform tokens = level.Find("Tokens");
        Transform barriers = level.Find("Barriers");
        Transform portals = level.Find("Portals");
        Transform platforms = level.Find("Platforms");

        //tokens.gameObject.AddComponent<TokenTracker>();
        tokenTracker = tokens.GetComponent<TokenTracker>();



        //// Locate all level settings and level gameObjects

        //levelInfo = info.gameObject;


        //foreach (Transform temp in shapes)
        //{
        //    playerShapeGOs.Add(temp.gameObject);
        //}

        //foreach (Transform temp in tokens)
        //{
        //    tokenGOs.Add(temp.gameObject);
        //}

        //foreach (Transform temp in barriers)
        //{
        //    barrierGOs.Add(temp.gameObject);
        //}

        //foreach (Transform temp in portals)
        //{
        //    portalGOs.Add(temp.gameObject);
        //}

        //foreach (Transform temp in platforms)
        //{
        //    platformGOs.Add(temp.gameObject);
        //}


        //// Change parent for each level gameObject

        //foreach (GameObject go in playerShapeGOs)
        //{
        //    go.transform.SetParent(shapeTracker);
        //}

        //foreach (GameObject go in tokenGOs)
        //{
        //    go.transform.SetParent(tokenTracker);
        //}

        //foreach (GameObject go in barrierGOs)
        //{
        //    go.transform.SetParent(barrierTracker);
        //}

        //foreach (GameObject go in portalGOs)
        //{
        //    go.transform.SetParent(portalTracker);
        //}

        //foreach (GameObject go in platformGOs)
        //{
        //    go.transform.SetParent(platformTracker);
        //}

    }

    public void initializeAllLevelObjects()
    {

        // Shapes
        foreach (GameObject go in playerShapeGOs)
        {
            go.GetComponent<Flip_Manager>().initializeAll();
        }


    }

    #endregion


    #region Game Loop

    public void mainGameLoop()
    {
        foreach (GameObject go in playerShapeGOs)
        {
            go.GetComponent<Flip_Manager>().updateFlipManager();
        }

        tokenTracker.updateTracker();

    }

    #endregion

}
