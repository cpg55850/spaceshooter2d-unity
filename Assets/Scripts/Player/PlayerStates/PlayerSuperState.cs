using UnityEngine;

public class PlayerSuperState : PlayerBaseState
{
    public float timeToExpire = 15f;
    float timer;
    bool timerReached = false;
    public float timerLimit = 7f;
    public override void EnterState(PlayerStateManager player)
    {
        SpriteRenderer sprite = player.GetComponent<SpriteRenderer>();
        sprite.color = Color.magenta;
        player.GetComponent<Shoot>().poweredUp = true;
        timer = 0f;
        timerReached = false;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > timerLimit)
        {
            player.SwitchState(player.DefaultState);

            //Set to false so that We don't run this again
            timerReached = true;
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {
    }
}
