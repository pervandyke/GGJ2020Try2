using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 origin;
    public GameObject target;
    public Vector3 target_location;
    public BulletEffects effect;

    public int damage;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (target != null)
        {
            target_location = target.transform.position;
        }

        if (timer >= 1f)
        {
            if (target != null)
            {
                HitTarget();
            }

            GameObject.Destroy(this.gameObject);
        }

        transform.position = Vector3.Lerp(origin, target_location, timer);
    }

    void HitTarget()
    {
        EnemyScript e_script = target.GetComponent<EnemyScript>();

        if (e_script is object) // Null check
        {
            e_script.TakeDamage(damage);
        }
    }
}

public enum BulletEffects
{
    DAMAGE,
    ACID,
    SLOW
}

