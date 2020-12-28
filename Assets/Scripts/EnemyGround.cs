using System.Collections;
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
            enemyObj.SendMessage("Flip");
            enemyObj.SendMessage("GroundEnd");

        }
    }
}
