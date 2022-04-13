using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public int speed = 15;
    public float despawnTime = 1.5f;
    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
