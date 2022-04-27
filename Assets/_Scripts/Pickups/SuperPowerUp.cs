using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerUp : PowerUp
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        PlayerStateManager playerStateManager = player.GetComponent<PlayerStateManager>();
        playerStateManager.SwitchState(playerStateManager.SuperState);
    }
}
