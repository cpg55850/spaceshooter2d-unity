using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : Health
{
    public static event Action<Health> onDamageTaken;

    public override void Start()
    {
        base.Start();
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        FindObjectOfType<AudioManager>().Play("Damage");
        onDamageTaken?.Invoke(GetComponent<Health>());
    }
}
