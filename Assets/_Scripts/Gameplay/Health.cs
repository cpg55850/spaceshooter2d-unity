using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject deathPrefab;
    public float hitFlashTime = 0.4f;
    private bool isFlashing = false;
    private Color startColor;
    private float t = 0;
    private SpriteRenderer sprite;

    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        startColor = sprite.color;
    }

    public virtual void TakeDamage(int amount)
    {
        if(gameObject.tag == "Enemy")
            FindObjectOfType<AudioManager>().Play("Hit");
        else if(gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Damage");
            GameManager.Instance.ShakeCamera(.25f, .25f);
        }

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

        Invoke("DestroyMe", 0.1f);
    }

    public void DestroyMe()
    {
        FindObjectOfType<AudioManager>().Play("Explode");
        Instantiate(deathPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public IEnumerator FlashRed()
    {
        Debug.Log("Flash");
        t = 0;

        if(!isFlashing)
        {
            isFlashing = true;
            startColor = sprite.color;
            while (t / hitFlashTime < 1)
            {
                Color newColor = Color.Lerp(Color.red, startColor, t / hitFlashTime);
                sprite.color = newColor;
                t += Time.deltaTime;
                yield return null;
            }
            isFlashing = false;
        }
    }
}
