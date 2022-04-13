using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerDefaultState DefaultState = new PlayerDefaultState();
    public PlayerSuperState SuperState = new PlayerSuperState();

    // Start is called before the first frame update
    void Start()
    {
        // starting state for the state machine
        currentState = DefaultState;
        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
