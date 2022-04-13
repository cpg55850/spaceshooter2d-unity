using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Health>() != null && !other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            gameObject.GetComponent<Health>().Die();
        }
    }

}
