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

    private void OnEnable()
    {
        PlayerHealth.onStart += drawPlayerHealth;
        PlayerHealth.onDamageTaken += drawPlayerHealth;
        HealthPowerUp.onGetHealth += drawPlayerHealth;
        EnemyHealth.onEnemyKilled += drawPlayerScore;
    }

    private void OnDisable()
    {
        PlayerHealth.onStart -= drawPlayerHealth;
        PlayerHealth.onDamageTaken -= drawPlayerHealth;
        HealthPowerUp.onGetHealth -= drawPlayerHealth;
        EnemyHealth.onEnemyKilled -= drawPlayerScore;
    }

    public void drawPlayerScore(Health health)
    {
        Debug.Log("draw Player score");

        scoreText.text = GameStateManager.Instance.score.ToString();
    }

    public void drawPlayerHealth(Health playerHealth)
    {
        Debug.Log("draw Player health");
        Debug.Log(playerHealth.health);
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
