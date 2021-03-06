﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    // get ref to EnemyController
    public GameObject enemyObj;
    EnemyController enemyCon;


    void Start()
    {
        enemyCon = enemyObj.GetComponent<EnemyController>();
    }

    //send message to the EnemyControllerSript
    private void OnTriggerExit(Collider ground)
    {
        if (ground.tag == "Floor")
        {
            //sends two messages, to be used in patrol or chase
           
            enemyObj.SendMessage("GroundEnd");

        }

        if (ground.tag == "Walls")
            enemyObj.SendMessage("GroundEnd");
    }
    
    private void OnTriggerEnter(Collider ground)
    {
        if (ground.tag == "Floor")
            enemyObj.SendMessage("GroundIn");
       //for wall run
        if (ground.tag == "Walls")
            enemyObj.SendMessage("GroundIn");

    }

    private void OnTriggerStay (Collider ground)
    {
        if (ground.tag == "Floor")
            enemyObj.SendMessage("GroundIn");
        //for wall run
        if (ground.tag == "Walls")
            enemyObj.SendMessage("GroundIn");
    }
}
