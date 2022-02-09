using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int points;
    public bool canDropItem;
    public GameObject droppableItem;
    public float dropPercentage;

    public override void Die()
    {
        base.Die();
        GameManager.Instance.IncreaseScore(points);
        if (canDropItem)
        {
            float rand = Random.Range(0f, 100f);
            if (rand < dropPercentage)
            {
                Instantiate(droppableItem, transform.position, transform.rotation);
            }
        }
    }
}
