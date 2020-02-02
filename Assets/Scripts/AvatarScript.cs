using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{
    public AvatarState state; 
    public float speed;
    public GameObject buildUI;
    public bool is_touching_ship;

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
                GameObject UIButtons = Instantiate(Resources.Load("Prefabs/BuildUIButtons1") as GameObject);
                UIButtons.transform.position = buildUI.transform.position;
                UIButtons.transform.SetParent(buildUI.transform);
                UIButtons.SetActive(true);
                
            }
            else
            {
                state = AvatarState.ACTIVE;
                buildUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            is_touching_ship = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            is_touching_ship = false;
        }
    }
}

public enum AvatarState
{
    INACTIVE,
    ACTIVE,
    BUILDING
}