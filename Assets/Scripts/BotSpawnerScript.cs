using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawnerScript : MonoBehaviour
{
    public GameObject robot;
    public float spawn_timer;
    public float spawn_rate_MIN;
    public float spawn_rate_MAX;

    // Start is called before the first frame update
    void Start()
    {
        GetNewSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;

        if (spawn_timer <= 0f)
        {
            GameObject.Instantiate(robot, transform);
            GetNewSpawnTime();
        }
    }

    void GetNewSpawnTime()
    {
        spawn_timer = Random.Range(spawn_rate_MIN, spawn_rate_MAX);
    }
}
