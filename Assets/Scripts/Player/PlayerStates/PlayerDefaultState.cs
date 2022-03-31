using UnityEngine;

public class PlayerDefaultState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player) {
        Debug.Log("Hello from the default state");
        SpriteRenderer sprite = player.GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
    }

    public override void UpdateState(PlayerStateManager player) { 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Yo from default state");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Switching to super state");
            player.SwitchState(player.SuperState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player) { 
    }
}
