using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private ResourceHealthSystem healthSystem;

   public void Setup(ResourceHealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.onHpChanged += healthSystem_onHpChanged;

    }

    private void healthSystem_onHpChanged (object sender, System.EventArgs e )
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.getHpPercent(), 1);

    }

   

}
