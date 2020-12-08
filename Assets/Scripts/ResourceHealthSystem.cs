//indipendent class
public class ResourceHealthSystem
{
    private int hp;
    public int hpMax;

    public ResourceHealthSystem (int hpMax)
    {
        this.hpMax = hpMax;
        hp = hpMax;

    }

    public int getHP()
    {
        return hp;

    }

    public float getHpPercent()
    {
        return hp / hpMax;


    }

    public void Damage (int dmgAmount)
    {
        hp -= dmgAmount;
        if (hp < 0)
        {
            hp = 0;
        }

    }
    public void Heal ( int healAmount)
    {
        hp += healAmount;
        if (hp < hpMax)
        {
            hp = hpMax;

        }
    }

}
