using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideBounds : MonoBehaviour
{
    private float objectWidth, objectHeight;
    public bool leftBoundary, rightBoundary, topBoundary, bottomBoundary;
    // Start is called before the first frame update
    void Start()
    {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < Screen.minX - (objectWidth / 2) && leftBoundary)
        {
            Destroy(gameObject);
        } else if (gameObject.transform.position.x > Screen.maxX + (objectWidth / 2) && rightBoundary)
        {
            Destroy(gameObject);
        } else if (gameObject.transform.position.y < Screen.minY - (objectWidth / 2) && topBoundary)
        {
            Destroy(gameObject);
        } else if (gameObject.transform.position.y > Screen.maxY + (objectWidth / 2) && bottomBoundary)
        {
            Destroy(gameObject);
        }
    }
}
