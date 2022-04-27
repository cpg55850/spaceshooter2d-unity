using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : StaticInstance<UIManager>
{
    public Text scoreText;
    public Text healthText;
    public Text waveText;
    public GameObject pausePanel;
    public float waveTextDuration = 1f;

    private void Start()
    {
        Debug.Log(GameStateManager.Instance.score.ToString());
        scoreText.text = GameStateManager.Instance.score.ToString();
        PlayerHealth.onDamageTaken += drawPlayerHealth;
        HealthPowerUp.onGetHealth += drawPlayerHealth;
    }

    private void OnDisable()
    {
        PlayerHealth.onDamageTaken -= drawPlayerHealth;
        HealthPowerUp.onGetHealth -= drawPlayerHealth;
    }

    public void drawPlayerScore()
    {
        Debug.Log("draw Player score");
        scoreText.text = GameStateManager.Instance.score.ToString();
    }

    public void drawPlayerHealth(Health playerHealth)
    {
        string healthString = "";
        for (int i = 0; i < playerHealth.health; i++)
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
