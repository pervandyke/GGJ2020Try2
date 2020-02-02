using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base3 : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        GetComponentInParent<BuildScript>().BaseSelected = 3;
    }
}
