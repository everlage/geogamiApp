using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShape : MonoBehaviour {

    public Flip_Manager flipManager;

    void Start()
    {
        flipManager.initializeAll();
    }

    // Update is called once per frame
    public void updatePlayerShape () 
    {
        flipManager.updateFlipManager();
    }


}
