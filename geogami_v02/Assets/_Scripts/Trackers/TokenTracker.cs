using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenTracker : MonoBehaviour {

    public List<Token> myTokens;


    bool levelComplete = false;


    void Start()
    {
        foreach (Transform child in transform)
        {
            Token childToken = child.gameObject.GetComponent<Token>();
            myTokens.Add(childToken);
        }
    }


    public void updateTracker()
    {
        if (transform.childCount < 1 && !levelComplete)
        {
            levelComplete = true;

            Debug.Log("LEVEL COMPLETE!");
            // TODO
        }
    }

    public void collectToken(Token token)
    {
        myTokens.Remove(token);
        Destroy(token);
    }
}
