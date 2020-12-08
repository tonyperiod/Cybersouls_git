using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public float cowardiceAngle = 5f;

    //get maxHP to this script to give different maxHP to enemies
    public GameObject RHS;
    ResourceHealthSystem rhsScript;
     private int maxHP;
    void Start()
    {
        // get script
        rhsScript = RHS.GetComponent<ResourceHealthSystem>();
        maxHP = rhsScript.hpMax;

        ResourceHealthSystem hpSyst = new ResourceHealthSystem(maxHP);
        Debug.Log("hp = " + hpSyst.getHpPercent());
        hpSyst.Damage(10);
        Debug.Log("hp = " + hpSyst.getHpPercent());
        hpSyst.Heal(10);
        Debug.Log("hp = " + hpSyst.getHpPercent());
    }
   

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
