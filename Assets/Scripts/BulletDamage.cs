using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    //get bullet stuff
    public GameObject bullet;
    public float bulletDmg;

    private void OnTriggerEnter(Collider other)
    {       
        //this way, can be used on enemies as well
        other.SendMessage("DealDmg", bulletDmg);
    }

}
