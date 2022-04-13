using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public MovementData movementData;
    private float yPos;
    private float objectWidth, objectHeight;
    private Vector3 _startPosition;
    private float degree;
    private float yDir;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
        degree = 0f;
        //yPos = transform.position.y + movementData.offset;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
        yDir = Random.Range(0, 2) * 2 - 1; // Value of -1 or 1
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
            case MovementData.Type.Bounce:
                BounceMovement();
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
        //transform.position = new Vector3(_startPosition.x - movementData.speed * Time.deltaTime, _startPosition.y + Mathf.Sin(movementData.frequency*Time.time) * movementData.magnitude, 0);
        Vector3 newPosition = transform.position;
        newPosition.x = newPosition.x - movementData.speed * Time.deltaTime;
        float offsetInRadians = movementData.offset / 57.2957367197f;
        newPosition.y = _startPosition.y + Mathf.Sin(offsetInRadians + degree) * movementData.magnitude;
        transform.position = newPosition;
        degree += movementData.frequency * Time.deltaTime;
    }

    private void BounceMovement()
    {
        transform.Translate(-movementData.speed * Time.deltaTime, movementData.speed * yDir * Time.deltaTime, 0);
        if (transform.position.y >= Screen.maxY - (objectHeight / 2) || transform.position.y <= Screen.minY + (objectHeight / 2))
        {
            yDir = -yDir;
        }
    }
}
