using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int points;
    public override void Die()
    {
        base.Die();
        GameManager.Instance.IncreaseScore(points);
    }
}
