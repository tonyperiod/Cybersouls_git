using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    

    //get stuff from player controller
    public GameObject PCT;
    PlayerController pctScript;
    private float aimAngleFloat;

    //will this fix
    public GameObject shoulder;


    void Start()
    {
        //get scripts
        pctScript = PCT.GetComponent<PlayerController>();
        aimAngleFloat = pctScript.aimAngleFloat;

        
    }

    //lateupdate cause it's after the player update
    void LateUpdate()
    {
        //rotate the shoulder
      aimAngleFloat = pctScript.aimAngleFloat;
        Vector3 vecrotation = new Vector3(0f, 0f, aimAngleFloat);
        Quaternion rotation = Quaternion.Euler(vecrotation);
       shoulder.transform.rotation = Quaternion.RotateTowards(shoulder.transform.rotation, rotation, 360f);





    }
    




}