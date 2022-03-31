using UnityEngine;

public class PlayerSuperState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        SpriteRenderer sprite = player.GetComponent<SpriteRenderer>();
        sprite.color = Color.magenta;
        player.GetComponent<Shoot>().poweredUp = true;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Yo from super state");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Switching to default state");
            player.GetComponent<Shoot>().poweredUp = false;
            player.SwitchState(player.DefaultState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {
    }
}
