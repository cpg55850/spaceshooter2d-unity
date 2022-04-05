using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public int secondsToDespawn = 10;

    private void Start()
    {
        Invoke("Exit", secondsToDespawn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Pickup(collision);
        }
    }

    public virtual void Pickup(Collider2D player) {
        Exit();
    }

    public virtual void Exit()
    {
        Destroy(gameObject);
    }
}
