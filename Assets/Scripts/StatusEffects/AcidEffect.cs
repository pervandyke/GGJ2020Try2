using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : Effect
{
    private GameObject enemy;
    private EnemyScript e_script;
    public float timer;
    public float timer_tick;
    public int damage_per_tick;

    private void Start()
    {
        life_timer = 2f;
        timer_tick = 0.5f;
        timer = timer_tick;
        damage_per_tick = 5;
    }

    public void AttachEnemy(GameObject a_enemy)
    {
        enemy = a_enemy;
        e_script = enemy.GetComponent<EnemyScript>();
    }

    public override void ProcessEffect()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer += timer_tick;
            if (enemy != null)
            {
                e_script.TakeDamage(damage_per_tick);
                Debug.Log("Ouch! I've taken " + damage_per_tick.ToString() + " damage!");
            }
        }

        base.ProcessEffect();
    }
}
