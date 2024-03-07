using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopped_tree : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Unit>())
        {
            Destroy(gameObject);
        }
    }
}
