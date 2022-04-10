using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeController : EnemyController
{
    public float frequency = 3f;
    public float magnitude = 5f;
    public float offset = 5f;
    private float yPos;
    public bool reverseDirection;

    public override void Start()
    {
        base.Start();
        //offset = Random.Range(0, 361);
        yPos = 0;
    }

    public override void MoveEnemy()
    {
        transform.Translate(-speed * Time.deltaTime, Mathf.Sin(yPos + offset) * magnitude * Time.deltaTime, 0);
        if (reverseDirection)
            yPos -= (0.1f * frequency);
        else
            yPos += (0.1f * frequency);
    }
}
