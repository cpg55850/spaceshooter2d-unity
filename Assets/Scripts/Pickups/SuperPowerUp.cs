using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerUp : PowerUp
{
    public override void Pickup(Collider2D player)
    {
        base.Pickup(player);
        PlayerStateManager playerStateManager = player.GetComponent<PlayerStateManager>();
        playerStateManager.SwitchState(playerStateManager.SuperState);
    }
}
