using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public float cowardiceAngle = 5f;

    public HealthBar hpbar;

    //get maxHP to this script to give different maxHP to enemies, get via the controllers
    

    //ResourceHealthSystem rhsScript;
    // private int maxHP;
    void Start()
    {

       // Debug.Log("i exist");
        // get script
        
        //maxHP = rhsScript.hpMax;
        //Debug.Log(maxHP);
        ResourceHealthSystem hpSyst = new ResourceHealthSystem(100);
        //Debug.Log("hp = " + hpSyst.getHpPercent());
        hpSyst.DealDmg(10);
        //Debug.Log("hp = " + hpSyst.getHpPercent());


        //setup health bar
        hpbar.Setup(hpSyst);
       
    }
  
    
  
}
