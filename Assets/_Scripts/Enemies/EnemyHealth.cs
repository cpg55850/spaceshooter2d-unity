using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
    public int points;
    public bool canDropItem;
    public GameObject[] droppableItems;
    public float dropPercentage = 5f;
    public CameraShake cameraShake;

    public static event Action<EnemyHealth> onEnemyKilled;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        FindObjectOfType<AudioManager>().Play("Hit");
    }

    public override void Die()
    {
        base.Die();

        GameStateManager.Instance.score += points;

        onEnemyKilled?.Invoke(this);

        if (canDropItem)
        {
            float rand = UnityEngine.Random.Range(0f, 100f);
            if (rand < dropPercentage)
            {
                float coinFlip = UnityEngine.Random.Range(0, 3);
                if (coinFlip > 1f)
                {
                    Instantiate(droppableItems[0], transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(droppableItems[1], transform.position, transform.rotation);
                }
            }
        }
    }
}
