using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base2 : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        GetComponentInParent<BuildScript>().BaseSelected = 2;
    }
}
