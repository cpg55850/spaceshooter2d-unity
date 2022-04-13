using UnityEngine;

public class PlayerDefaultState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        SpriteRenderer sprite = player.GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
        player.GetComponent<Shoot>().poweredUp = false;
    }

    public override void UpdateState(PlayerStateManager player) { 

    }

    public override void OnCollisionEnter(PlayerStateManager player) { 
    }
}
