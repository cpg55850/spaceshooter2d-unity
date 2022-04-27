using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : Health
{
    public static event Action<Health> onDamageTaken;
    public static event Action<Health> onStart;

    public override void Start()
    {
        base.Start();
        Debug.Log("Player health started...");
        onStart?.Invoke(this);
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        FindObjectOfType<AudioManager>().Play("Damage");
        onDamageTaken?.Invoke(this);
    }
}
