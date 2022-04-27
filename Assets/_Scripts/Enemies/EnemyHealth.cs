using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
    public static event Action<Health> onEnemyKilled;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        FindObjectOfType<AudioManager>().Play("Hit");
    }

    public override void Die()
    {
        base.Die();
        EnemyData enemyData = GetComponent<EnemyController>().enemyData;

        GameStateManager.Instance.score += enemyData.points;
        
        onEnemyKilled?.Invoke(this);

        if (enemyData.canDropItem)
        {
            float rand = UnityEngine.Random.Range(0f, 100f);
            if (rand < enemyData.dropPercentage)
            {
                float coinFlip = UnityEngine.Random.Range(0, 3);
                if (coinFlip > 1f)
                {
                    Instantiate(enemyData.droppableItems[0], transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(enemyData.droppableItems[1], transform.position, transform.rotation);
                }
            }
        }
    }
}
