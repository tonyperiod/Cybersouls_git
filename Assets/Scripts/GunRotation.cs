using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    

    //get stuff from player controller
    public GameObject PCT;
    PlayerController pctScript;
    private float aimAngleFloat;


    void Start()
    {
        //get scripts
        pctScript = PCT.GetComponent<PlayerController>();
        aimAngleFloat = pctScript.aimAngleFloat;
    }

    //lateupdate cause it's after the player update
    void LateUpdate()
    {

      aimAngleFloat = pctScript.aimAngleFloat;
               
    }






}