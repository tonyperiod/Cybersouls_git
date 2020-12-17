//indipendent class
using System;

public class ResourceHealthSystem
{
    //so hp bar modifies only when hp takes dmg for efficiency sake
    public event EventHandler onHpChanged;

    private float hp;
    public int hpMax;

    public ResourceHealthSystem (int hpMax)
    {
        this.hpMax = hpMax;
        hp = hpMax;

    }

    public float getHP()
    {
        return hp;

    }

    public float getHpPercent()
    {
        return hp / hpMax;        
    }

    public void DealDmg(float amount)
    {
        hp -= amount;
        if (hp < 0)
        {
            hp = 0;
        }

        if (onHpChanged != null) onHpChanged(this, EventArgs.Empty);



    }
        // if I want to put in later in the game the healing
    //}
    //public void Heal ( float healAmount)
    //{
    //    hp += healAmount;
    //    if (hp < hpMax)
    //    {
    //        hp = hpMax;

    //    }
    

}
