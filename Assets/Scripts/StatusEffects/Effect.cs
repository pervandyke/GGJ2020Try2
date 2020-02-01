using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float life_timer;
    public bool ready_to_delete;

    public virtual void ProcessEffect()
    {
        life_timer -= Time.deltaTime;

        if (life_timer <= 0f)
        {
            ready_to_delete = true;
        }
    }
}
