using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public MovementData movementData;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        yPos = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(movementData?.type)
        {
            case MovementData.Type.Straight:
                StraightMovement();
                break;
            case MovementData.Type.Sinusoidal:
                SinusoidalMovement();
                break;
            default:
                break;
        }

    }

    private void StraightMovement()
    {
        transform.Translate(-movementData.speed * Time.deltaTime, 0, 0);
    }

    private void SinusoidalMovement()
    {
        transform.Translate(-movementData.speed * Time.deltaTime, Mathf.Sin(yPos + movementData.offset) * movementData.magnitude * Time.deltaTime, 0);
        yPos += (0.1f * movementData.frequency);
    }
}
