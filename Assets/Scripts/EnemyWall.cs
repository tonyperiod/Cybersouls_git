using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    // get ref to EnemyController
    public GameObject enemyObj;
    EnemyController enemyCon;


    void Start()
    {
        enemyCon = enemyObj.GetComponent<EnemyController>();
    }

    //send message to the EnemyControllerSript
    private void OnTriggerEnter(Collider wall)
    {
        if (wall.tag == "Walls")
        {
            enemyObj.SendMessage("Flip");
            enemyObj.SendMessage("WallHit");

        }
    }
}
