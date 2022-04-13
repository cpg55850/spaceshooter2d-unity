using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Text scoreText;
    public Text healthText;
    public Text waveText;
    public GameObject pausePanel;
    public float waveTextDuration = 1f;
    public GameObject player;
    public int score = 0;
    public CameraShake cameraShake;

    void Awake()
    {
        Instance = this;
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Start()
    {
        //drawHealth(player.GetComponent<Health>().health);
    }

    private void Update()
    {
        if(player)
        {
            drawHealth(player.GetComponent<Health>().health);
        }
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        StartCoroutine(cameraShake.Shake(duration, magnitude));
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

    public IEnumerator drawWave(string wave)
    {
        waveText.text = wave;
        yield return new WaitForSeconds(waveTextDuration);
        waveText.text = "";
    }
}
