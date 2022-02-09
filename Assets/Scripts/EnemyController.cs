using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float objectWidth, objectHeight;
    public float speed = 3f;
    public int damage;
    private int yDir;
    public bool bounceOnY;

    // Start is called before the first frame update
    void Start()
    {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
        yDir = Random.Range(0, 2) * 2 - 1; // Value of -1 or 1
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(bounceOnY)
        {
            MoveEnemyBounce();
        } else
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void MoveEnemyBounce()
    {
        transform.Translate(-speed * Time.deltaTime, speed * yDir * Time.deltaTime, 0);
        if (transform.position.y >= GameManager.Instance.maxY - (objectHeight / 2) || transform.position.y <= GameManager.Instance.minY + (objectHeight / 2))
        {
            yDir = -yDir;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            gameObject.GetComponent<Health>().Die();
        }
    }

}
