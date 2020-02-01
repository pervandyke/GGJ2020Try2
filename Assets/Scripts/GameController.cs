using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        //enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemies();
        ProcessEnemies();
    }

    void GetEnemies()
    {
        enemies = new List<GameObject>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void ProcessEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            /*if (enemy.ready_to_delete)
            {
                GameObject.Destroy(enemy);
                ProcessEnemyDrop();
            }*/
        }
    }

    void ProcessEnemyDrop()
    {
        Debug.Log("Ow!");
    }
}
