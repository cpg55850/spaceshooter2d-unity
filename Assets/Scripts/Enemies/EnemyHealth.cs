using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int points;
    public bool canDropItem;
    public GameObject[] droppableItems;
    public float dropPercentage = 5f;
    public CameraShake cameraShake;

    public override void Die()
    {
        base.Die();
        GameManager.Instance.IncreaseScore(points);
        GameManager.Instance.ShakeCamera(.15f, .15f);

        if (canDropItem)
        {
            float rand = Random.Range(0f, 100f);
            if (rand < dropPercentage)
            {
                float coinFlip = Random.Range(0, 3);
                Debug.Log("Coin Flip: " + coinFlip);
                if(coinFlip > 1f)
                {
                    Instantiate(droppableItems[0], transform.position, transform.rotation);
                } else
                {
                    Instantiate(droppableItems[1], transform.position, transform.rotation);
                }
            }
        }
    }
}
