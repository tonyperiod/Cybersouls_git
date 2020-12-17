using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSkillManager : MonoBehaviour
{
    /**
    public List<Skill> allSkills = new List<Skill>();
    private List<Skill_Slot> slots = new List<Skill_Slot>();

    public PlayerController player;

    public GameObject skillSpacer;
    public GameObject skillSlot;

  


    void Start()
    {
        for (int i = 0; i < allSkills.Count; i++)
        {
            GameObject go = Instantiate(skillSlot, Vector3.zero, Quaternion.identity);
            Skill_Slot slot = GetComponent<Skill_Slot>;

            slot.init(allSkills[i], this, player);

            slot.add(slot);

            go.transform.SetParent(skillSpacer.transform);

        }
    }

    public void UpdateAllSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].UpdateUI(); // this is for xp system, will take care of later

            
        }
    }
    **/
}
