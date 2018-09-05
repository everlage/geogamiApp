using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public AngleZone angleZoneScript;


    public int numberOfFadesIllegalFlipAnimation = 2;
    public float fadeOutTime = 0.1f;
    public float fadeInTime = 0.1f;
    public float fadeOutAlpha = 0.5f;


    bool legalMove;
    bool runningAnimation;

    Material ghostMatLegal;
    Material ghostMatNotLegal;






    public void initialize(Material legalMat, Material notLegalMat)
    {
        ghostMatLegal = legalMat;
        ghostMatNotLegal = notLegalMat;

        resetBarrierDetection();
        angleZoneScript.exitZone();
    }





    public bool isLegalMove()
    {

        return legalMove;
    }



    public void hitBarrier()
    {

        legalMove = false;
        updateMyMaterial();
    }

    public void resetBarrierDetection()
    {

        legalMove = true;
        updateMyMaterial();
    }

    public void prepareForFlip()
    {
        //TODO

        angleZoneScript.exitZone();
    }


    // Materials and Animation

    public void updateMyMaterial()
    {
        // TODO
        if(legalMove)
        {
            gameObject.GetComponent<MeshRenderer>().material = ghostMatLegal;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = ghostMatNotLegal;
        }
    }

    public void runIllegalFlipAnimation()
    {
        //TODO

        Debug.Log("runIllegalFlipAnimation");
        StartCoroutine("illigalFlipAnimation");

        //anim.Play("Ghost_Illegal_Flip"); //SetTrigger("Illegal Move");
    }

    IEnumerator illigalFlipAnimation()
    {
        runningAnimation = true;

        float alphaOriginal = GetComponent<Renderer>().material.color.a;
        Color newColor = GetComponent<Renderer>().material.color;

        // Get material
        // Record current alpha

        for (int n = 0; n < numberOfFadesIllegalFlipAnimation; n ++)
        {
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeOutTime)
            {
                newColor.a = Mathf.Lerp(alphaOriginal, fadeOutAlpha, t);
                GetComponent<Renderer>().material.SetColor("_Color", newColor);
                yield return null;
            }

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeInTime)
            {
                newColor.a = Mathf.Lerp(fadeOutAlpha, alphaOriginal, t);
                GetComponent<Renderer>().material.SetColor("_Color", newColor);
                yield return null;
            }
        }

        runningAnimation = false;
    }




}
