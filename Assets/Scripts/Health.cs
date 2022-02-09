using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject deathPrefab;

    public virtual void TakeDamage(int amount)
    {
        FindObjectOfType<AudioManager>().Play("Hit");
        StartCoroutine(FlashRed());
        health -= amount;
        if (health <= 0)
            Die();
    }

    public void addHealth(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
    }

    public virtual void Die()
    {
        FindObjectOfType<AudioManager>().Play("Explode");
        Instantiate(deathPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public IEnumerator FlashRed()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
