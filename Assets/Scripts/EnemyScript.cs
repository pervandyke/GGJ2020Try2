using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public float speed;
    public List<Vector2> path;
    public List<Effect> effects;
    public bool ready_to_delete;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        path = new List<Vector2>();
        path.Add(new Vector2(-5.5f, 0));
        path.Add(new Vector2(-5.5f, 3));
        path.Add(new Vector2(-2.5f, 3));
        path.Add(new Vector2(-2.5f, -3));
        path.Add(new Vector2(2.5f, -3));
        path.Add(new Vector2(2.5f, -1));
        path.Add(new Vector2(6.5f, -1));
        path.Add(new Vector2(6.5f, 2));
    }

    // Update is called once per frame
    void Update()
    {
        ProcessEffects();

        if (path.Count != 0)
        {
            ProcessMove();
        }
        else
        {

        }
    }

    public void ProcessMove()
    {
        Vector2 waypoint = path[0];

        Vector2 movedirection = new Vector2();
        movedirection.x = waypoint.x - transform.position.x;
        movedirection.y = waypoint.y - transform.position.y;
        movedirection = movedirection.normalized;

        transform.Translate(movedirection * speed * Time.deltaTime);
        if (Mathf.Abs(waypoint.x - transform.position.x) <= 0.1f && Mathf.Abs(waypoint.y - transform.position.y) <= 0.1f)
        {
            path.RemoveAt(0);
        }
    }

    public void ProcessEffects()
    {
        foreach (Effect enemy_effect in effects)
        {
            enemy_effect.ProcessEffect();
            if (enemy_effect.ready_to_delete)
            {
                effects.Remove(enemy_effect);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            ready_to_delete = true;
        }
    }

    public void ApplyEffect(BulletEffects effect)
    {

    }
}
