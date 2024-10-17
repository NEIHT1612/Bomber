using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destructibleTime = 1f;

    private void Start()
    {
        Destroy(gameObject, destructibleTime);
    }
}
