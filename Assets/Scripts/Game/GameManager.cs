using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Text scoreText;
    public Text healthText;
    public GameObject player;
    public float minX, maxX, minY, maxY;
    public int score = 0;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        initializeScreenBoundVariables();
        //drawHealth(player.GetComponent<Health>().health);
    }

    private void Update()
    {
        if(player)
        {
            drawHealth(player.GetComponent<Health>().health);
        }
    }

    public void initializeScreenBoundVariables()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void drawHealth(int health)
    {
        string healthString = "";
        for(int i = 0; i < health; i++)
        {
            healthString += "* ";
        }

        healthText.text = healthString;
    }
}
