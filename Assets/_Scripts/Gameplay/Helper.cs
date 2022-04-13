using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public float frequency = 3f;
    public float magnitude = 70f;
    public float offset = 5f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + Mathf.Cos(Time.time * frequency + offset) * magnitude * Time.deltaTime, player.transform.position.y + Mathf.Sin(Time.time * frequency + offset) * magnitude * Time.deltaTime);
    }
}
