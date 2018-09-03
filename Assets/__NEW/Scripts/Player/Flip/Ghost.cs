using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public AngleZone angleZoneScript;



    bool legalMove;
    bool runningAnimation;

    Material ghostMatLegal;
    Material ghostMatNotLegal;

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void initialize(Material legalMat, Material notLegalMat)
    {
        ghostMatLegal = legalMat;
        ghostMatNotLegal = notLegalMat;

        resetBarrierDetection();
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
        //StartCoroutine("illigalFlipAnimation");

        anim.Play("Ghost_Illegal_Flip"); //SetTrigger("Illegal Move");
    }

    //IEnumerator illigalFlipAnimation()
    //{
        //runningAnimation = true;

        //for (int i = 0; i < angle; i += flipSpeed)
        //{
        //    transform.RotateAround(rotationPoint, rotationAxis, flipSpeed * rotationSign);
        //    yield return null;
        //}

        //fixDrift(); // Fix floating point errors caused by rotation

        //rotating = false;
    //}


}
