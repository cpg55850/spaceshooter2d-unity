using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeController : MonoBehaviour
{
    public EnemyData enemyData;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(enemyData.damage);
            gameObject.GetComponent<Health>().Die();
        }
    }

}
