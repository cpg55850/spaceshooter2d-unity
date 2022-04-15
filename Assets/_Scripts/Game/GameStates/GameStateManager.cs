using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : StaticInstance<GameStateManager>
{
    GameBaseState currentState;
    public GameIntroState IntroState = new GameIntroState();
    public GamePlayState PlayState = new GamePlayState();

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // starting state for the state machine
        currentState = IntroState;
        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(score);
        }
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
