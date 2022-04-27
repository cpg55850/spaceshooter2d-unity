using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PowerUp : MonoBehaviour
{
    public int secondsToDespawn = 10;

    private void Start()
    {
        Invoke("Exit", secondsToDespawn);
    }

    public virtual void Exit()
    {
        Destroy(gameObject);
    }
}
