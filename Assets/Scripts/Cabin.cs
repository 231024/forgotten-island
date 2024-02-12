using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabin : MonoBehaviour
{
    public event Action Touched ;

    private void OnMouseDown()
    {
        Touched?.Invoke();
    }
}
