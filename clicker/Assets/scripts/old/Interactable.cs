using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interactable
{

    public Health health { get; set; }
    private Button button { get; set; }
    public string displayName { get; set; }

    //InteractableVisuals visuals;
    //LootTable loot;
    //KillTable kill;
    //int lastLootThreshold;

    // Use this for initialization
    public Interactable()
    {
        health = new Health();
        //visuals = new InteractableVisuals();
        //loot = new LootTable();
        //kill = new KillTable();
        //lastLootThreshold = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (health.IsAlive)
        {
            health.Decay();
        }

        if (!health.IsAlive)
        {
            // I am dead, generate kill loot
        }
    }

    // int damage should be a DamageObject later, but that's not implemented atm
    public bool Damage(float damage)
    {
        var didDamage = false;
        var damageDealt = health.Damage(damage, ref didDamage);
        //if (lastLootThreshold != health.currentLootThreshold)
        //{
        //    lastLootThreshold = health.currentLootThreshold;
        //    // Generate loot from loot threshold
        //}
        Debug.Log(string.Format("{0} Health: {1}", displayName, health.CurrentHealth));
        return didDamage;
    }
}
