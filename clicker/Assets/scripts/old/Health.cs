using UnityEngine;
using System.Collections;
using System;

public class Health
{
    public float BaseHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float DecayRate { get; set; }

    public float HealthPercent
    {
        get
        {
            return CurrentHealth / BaseHealth;
        }
    }

    public Health()
    {
        BaseHealth = 1000;
        CurrentHealth = BaseHealth;
        DecayRate = 50;
    }

    public float Damage(float damage, ref bool didDamage)
    {
        didDamage = true;
        CurrentHealth -= damage;
        return damage;
    }

    public bool IsAlive
    {
        get
        {
            return CurrentHealth > 0;
        }
    }

    public void Decay()
    {
        CurrentHealth -= DecayRate;
    }
}
