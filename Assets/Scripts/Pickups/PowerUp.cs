using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public int secondsToDespawn;

    private void Start()
    {
        StartCoroutine(Disappear(secondsToDespawn));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Pickup(collision);
        }
    }

    public virtual void Pickup(Collider2D player) {
        Destroy(gameObject);
    }

    IEnumerator Disappear(int secondsToDespawn)
    {
        yield return new WaitForSeconds(secondsToDespawn);
        Destroy(gameObject);
    }
}
