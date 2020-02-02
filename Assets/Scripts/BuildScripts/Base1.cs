using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base1 : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        GetComponentInParent<BuildScript>().BaseSelected = 1;
    }
}
