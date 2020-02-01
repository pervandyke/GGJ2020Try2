using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{
    public AvatarState state; 
    public float speed;
    public GameObject buildUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Keybinds();

        switch (state)
        {
            case AvatarState.INACTIVE:
                UpdateInactive();
                break;
            case AvatarState.ACTIVE:
                UpdateActive();
                break;
            case AvatarState.BUILDING:
                UpdateBuilding();
                break;
            default:
                break;
        }
    }

    void UpdateInactive()
    {
    }

    void UpdateActive()
    {
        Vector2 movedirection = new Vector2();
        movedirection.x = Input.GetAxis("Horizontal");
        movedirection.y = Input.GetAxis("Vertical");
        movedirection = movedirection.normalized;

        transform.Translate(movedirection * speed * Time.deltaTime);
    }

    void UpdateBuilding()
    {
        
    }

    void Keybinds()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (state == AvatarState.ACTIVE)
            {
                state = AvatarState.BUILDING;
                buildUI.SetActive(true);
            }
            else
            {
                state = AvatarState.ACTIVE;
                buildUI.SetActive(false);
            }
        }
    }
}

public enum AvatarState
{
    INACTIVE,
    ACTIVE,
    BUILDING
}