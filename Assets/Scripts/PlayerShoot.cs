using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   // resource manager get
    public GameObject RM;
    ResourceManager rmScript;
    private float cowardiceAngle;

    // playercone get
    public GameObject PC;
    PlayerCone pcScript;

    private float aimAngleFloat;

    //shooty stuff
    private float shootAngleFloat;


    void Start()
    {
        //get scripts
        rmScript = RM.GetComponent<ResourceManager>();
        pcScript = PC.GetComponent<PlayerCone>();

   

       


    }


    void LateUpdate ()
    {
        // get shoot angle
        cowardiceAngle = rmScript.cowardiceAngle;
        aimAngleFloat = pcScript.aimAngleFloat;
        shootAngleFloat = aimAngleFloat;
        shootAngleFloat += Random.Range(-cowardiceAngle, 0);
    }
}
