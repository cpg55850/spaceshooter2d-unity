using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    public int amount;

    public override void Pickup(Collider2D player)
    {
        player.GetComponent<Health>().addHealth(amount);
        base.Pickup(player);
    }
}
