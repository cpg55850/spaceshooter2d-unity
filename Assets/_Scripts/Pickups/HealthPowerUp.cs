using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPowerUp : PowerUp
{
    public int amount;
    public static event Action<Health> onGetHealth;

    private void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("Triggered a health powerup");
        player.GetComponent<Health>().addHealth(amount);
        onGetHealth?.Invoke(player.GetComponent<Health>());
        PlayDefaultSFX();
        Exit();
    }
}
