using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject deathPrefab;

    public void TakeDamage(int amount)
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        StartCoroutine(FlashRed());
        health -= amount;
        if (health <= 0)
            Die();
    }

    public virtual void Die()
    {
        FindObjectOfType<AudioManager>().Play("Explode");
        Instantiate(deathPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public IEnumerator FlashRed()
    {
        Debug.Log("Flash");
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
