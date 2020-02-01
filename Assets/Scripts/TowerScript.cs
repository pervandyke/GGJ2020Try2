using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    // Tower components
    public GameController game_controller;
    public GameObject tower_base;
    public GameObject tower_turret;
    public GameObject tower_core;
    public GameObject bullet_type;

    // Tower stats
    private float shot_rate;
    private float shot_timer;
    public float shot_rate_base;
    private float shot_radius;
    public float shot_radius_base;
    private int shot_damage;
    public int shot_damage_base;

    // Control variables
    private bool is_active;
    private bool can_shoot;

    // Start is called before the first frame update
    void Start()
    {
        is_active = true;
        can_shoot = true;

        game_controller = GameObject.FindObjectOfType<GameController>();

        shot_rate = shot_rate_base;
        shot_timer = 0f;
        shot_radius = shot_radius_base;

        CalculateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_active)
        {
            UpdateTimer();

            if (can_shoot)
            {
                FindTarget();
            }
        }
    }

    void CalculateStats()
    {
        TowerBase t_base = tower_base.GetComponent<TowerBase>();
        TowerTurret t_turret = tower_turret.GetComponent<TowerTurret>();
        TowerCore t_core = tower_core.GetComponent<TowerCore>();

        shot_rate = shot_rate_base * t_base.firerate_ratio * t_turret.firerate_ratio;
        shot_radius = shot_radius_base * t_turret.radius_ratio;
        shot_damage = (int)(shot_damage_base * t_turret.damage_ratio);
        bullet_type = t_core.bullet_type;
    }

    void UpdateTimer()
    {
        if (shot_timer >= 0f)
        {
            shot_timer -= Time.deltaTime;
        }
        else
        {
            can_shoot = true;
        }
    }

    void FindTarget()
    {
        foreach (GameObject enemy in game_controller.enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= shot_radius)
            {
                Shoot(enemy);
                can_shoot = false;
                shot_timer = shot_rate;
                return;
            }
        }
    }

    void Shoot(GameObject target)
    {
        GameObject bullet = GameObject.Instantiate(bullet_type, gameObject.transform);
        BulletScript b_script = bullet.GetComponent<BulletScript>();

        b_script.damage = shot_damage;
        b_script.target = target;
    }
}
