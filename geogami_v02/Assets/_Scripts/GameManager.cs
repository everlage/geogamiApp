using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Inspector variables

    // ---------- Level Info
    public GameObject levelInfo; //TODO Not yet implemented

    // ---------- Shapes
    public ShapeTracker shapeTracker;

    // ---------- Tokens
    public TokenTracker tokenTracker;

    // ---------- Barriers
    public BarrierTracker barrierTracker;

    // ---------- Portals
    public PortalTracker portalTracker;

    // ---------- Platforms
    public PlatformTracker platformTracker;

    #endregion

    #region Game Status variables


    bool animationRunning;


    #endregion


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
        levelInfo = level.gameObject; //TODO Not yet implemented


        Transform info = level.Find("Level Info");
        Transform shapes = level.Find("Shapes");
        Transform tokens = level.Find("Tokens");
        Transform barriers = level.Find("Barriers");
        Transform portals = level.Find("Portals");
        Transform platforms = level.Find("Platforms");

        shapeTracker = shapes.GetComponent<ShapeTracker>();
        tokenTracker = tokens.GetComponent<TokenTracker>();
        barrierTracker = barriers.GetComponent<BarrierTracker>();
        portalTracker = portals.GetComponent<PortalTracker>();
        platformTracker = platforms.GetComponent<PlatformTracker>();


    }

    public void initializeAllLevelObjects()
    {

      

    }

    #endregion


    #region Game Loop

    public void mainGameLoop()
    {
        // Check for mouse input

        shapeTracker.updateTracker();

        tokenTracker.updateTracker();

    }

    #endregion

}
