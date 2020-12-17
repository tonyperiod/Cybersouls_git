using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//so i can modify in the inspector
[System.Serializable]
//modified this so it's instanced, not a scriptable object
public class PlayerAbility
{
    public string abilityName;
    public float abilityAmount;
    public float maxAbilityNumber;

    public AbilityType abilitytype;

    public PlayerAbility(string abilityName, float abilityAmount, float maxAbilityNumber, AbilityType abilitytype)
    {
        this.abilityName = abilityName;
        this.abilityAmount = abilityAmount;
        this.maxAbilityNumber = maxAbilityNumber;
        this.abilitytype = abilitytype;
    }

    public enum AbilityType { Mobility, Defensive, Offensive };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
