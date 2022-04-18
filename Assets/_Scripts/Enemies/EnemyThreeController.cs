using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeController : MonoBehaviour
{
    public int damage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            gameObject.GetComponent<Health>().Die();
        }
    }

}
