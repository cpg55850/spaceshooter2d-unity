using UnityEngine;
using System;

public class GameIntroState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("Intro state!");
    }

    public override void UpdateState(GameStateManager game)
    {
        game.SwitchState(game.PlayState);
    }

    public override void OnCollisionEnter(GameStateManager game)
    {
    }
}
