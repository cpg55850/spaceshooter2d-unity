using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeController : EnemyController
{
    public float frequency = 3f;
    public float magnitude = 5f;
    public float offset = 5f;

    public override void Start()
    {
        base.Start();
        offset = Random.Range(0, 361);
    }

    public override void MoveEnemy()
    {
        transform.Translate(-speed * Time.deltaTime, Mathf.Sin(Time.time * frequency + offset) * magnitude * Time.deltaTime, 0);
    }
}
