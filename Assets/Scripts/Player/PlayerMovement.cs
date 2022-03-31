using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float objectWidth, objectHeight;

    public float speed = 12f;
    private Rigidbody2D rb;



    void Start()
    {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        float ver = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        Vector2 direction = new Vector2(hor, ver).normalized;
        direction *= speed * Time.deltaTime;

        float xValidPosition = Mathf.Clamp(transform.position.x + direction.x, GameManager.Instance.minX + (objectWidth / 2), GameManager.Instance.maxX - (objectWidth / 2));
        float yValidPosition = Mathf.Clamp(transform.position.y + direction.y, GameManager.Instance.minY + (objectHeight / 2), GameManager.Instance.maxY - (objectHeight / 2));

        transform.position = new Vector3(xValidPosition, yValidPosition, 0f);
        //Vector2 temp = transform.position;
        //if (Input.GetAxisRaw("Vertical") > 0f)
        //{
        //    temp.y += speed * Time.deltaTime;
        //}
        //else if (Input.GetAxisRaw("Vertical") < 0f)
        //{
        //    temp.y -= speed * Time.deltaTime;
        //}

        //temp.y = Mathf.Clamp(temp.y, GameManager.Instance.minY + (objectHeight / 2), GameManager.Instance.maxY - (objectHeight / 2));
        //transform.position = temp;
    }
}
