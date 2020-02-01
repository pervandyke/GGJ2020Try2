using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : Effect
{
    private EnemyScript enemy;
    public float timer;
    public float timer_tick;
    public int damage_per_tick;

    private void Start()
    {
        enemy = GetComponent<EnemyScript>();
    }

    public override void ProcessEffect()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer += timer_tick;
            enemy.TakeDamage(damage_per_tick);
            Debug.Log("Ouch! I've taken " + damage_per_tick.ToString() + " damage!");
        }

        base.ProcessEffect();
    }
}
