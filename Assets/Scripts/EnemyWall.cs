using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    // get ref to EnemyController
    public GameObject enemyObj;
    EnemyController enemyCon;

    //this collider is perfect also to track collisions with the player
    //will use the same script and collider for both
    void Start()
    {
        enemyCon = enemyObj.GetComponent<EnemyController>();
    }

    //send message to the EnemyControllerSript
    private void OnTriggerEnter(Collider wall)
    {
        //for patrol and chase   
        if (wall.tag == "Walls")
        {                    
            enemyObj.SendMessage("WallHit");
        }

        // for attack
        if (wall.tag == "Player")
        {
            enemyObj.SendMessage("EnemyHit");

        }
    }
    //only for patrol
    private void OnTriggerExit(Collider wall)
    {
        if (wall.tag == "Walls")
        {  
            enemyObj.SendMessage("WallOut");
        }

        //for attack
        if (wall.tag == "Player")
        {
            enemyObj.SendMessage("EnemyOut");
        }
    }

    private void OnTriggerStay(Collider wall)
    {
        if (wall.tag == "Walls")
            enemyObj.SendMessage("WallHit");
    }

    
}

