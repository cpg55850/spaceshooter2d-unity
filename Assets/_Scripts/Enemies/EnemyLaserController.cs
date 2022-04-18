using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserController : LaserController
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
