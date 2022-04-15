using UnityEngine;

public class GamePlayState : GameBaseState
{
    public override void EnterState(GameStateManager game) {
        Debug.Log("Play state!");
    }

    public override void UpdateState(GameStateManager game) { 

    }

    public override void OnCollisionEnter(GameStateManager game) { 
    }
}
