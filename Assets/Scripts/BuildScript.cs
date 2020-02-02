using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{

    public int BaseSelected = 0;
    public int CoreSelected = 0;
    public int GunSelected = 0;
    public bool step2bool = false;
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (BaseSelected != 0)
        {
            GameObject CoreButtons = Instantiate(Resources.Load("Prefabs/BuildUIButtons2") as GameObject);
            CoreButtons.transform.position = gameObject.transform.position;
            CoreButtons.transform.SetParent(gameObject.transform);
            CoreButtons.SetActive(true);
            Destroy(GameObject.Find("BuildUIButtons1(Clone)"));
        }

        
    }


}
