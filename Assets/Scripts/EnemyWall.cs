using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{

    public GameObject enemyCon;


    private void OnTriggerEnter(Collider wall)
    {
        if (wall.tag == "Wall")
        {
            

        }
    }
}
