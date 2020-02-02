using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> enemies;

    // Player Resources
    public int steel_count;
    public int plastic_count;
    public int clockwork_count;
    public int sniper_count;
    public int pulse_count;
    public int shell_count;
    public int damage_count;
    public int slow_count;
    public int acid_count;

    // Ship parts
    public bool has_engine;
    public bool has_cable;
    public bool has_computer;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();

        steel_count = 0;
        plastic_count = 0;
        clockwork_count = 0;
        sniper_count = 0;
        pulse_count = 0;
        shell_count = 0;
        damage_count = 0;
        slow_count = 0;
        acid_count = 0;
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
            EnemyScript e_script = enemy.GetComponent<EnemyScript>();

            if (e_script is object)
            {
                if (e_script.ready_to_delete)
                {
                    GameObject.Destroy(enemy);
                    ProcessEnemyDrop();
                    ProcessShipDrop();
                }
            }
        }
    }

    void ProcessEnemyDrop()
    {
        int option = (int)Random.Range(1f, 10f);
        int quantity = (int)Random.Range(1f, 4f);

        switch (option)
        {
            case 1:
                steel_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " STEEL");
                break;
            case 2:
                plastic_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " PLASTIC");
                break;
            case 3:
                clockwork_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " CLOCKWORK");
                break;
            case 4:
                sniper_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " SNIPER");
                break;
            case 5:
                pulse_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " PULSE");
                break;
            case 6:
                shell_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " SHELL");
                break;
            case 7:
                damage_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " DAMAGE");
                break;
            case 8:
                slow_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " SLOW");
                break;
            case 9:
                acid_count += quantity;
                Debug.Log("You got " + quantity.ToString() + " ACID");
                break;
            default:
                break;
        }
    }

    void ProcessShipDrop()
    {
        int option = (int)Random.Range(1f, 201f);

        switch (option)
        {
            case 1:
                if (!has_engine)
                {
                    has_engine = true;
                    Debug.Log("You got the ENGINE!!");
                }
                break;
            case 2:
                if (!has_cable)
                {
                    has_cable = true;
                    Debug.Log("You got the POWER CABLES!!");
                }
                break;
            case 3:
                if (!has_computer)
                {
                    has_computer = true;
                    Debug.Log("You got the NAVIGATION COMPUTER!!");
                }
                break;
            default:
                break;
        }
    }
}
