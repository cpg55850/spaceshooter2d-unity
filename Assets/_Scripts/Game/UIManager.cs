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

    protected override void Awake()
    {
        base.Awake();
        PlayerHealth.onDamageTaken += drawPlayerHealth;
        PlayerHealth.onStart += drawPlayerHealth;
        EnemyHealth.onEnemyKilled += drawPlayerScore;
    }

    private void Start()
    {
        Debug.Log("Start! Score: " + GameStateManager.Instance.score.ToString());
        scoreText.text = GameStateManager.Instance.score.ToString();
    }

    private void OnDestroy()
    {
        PlayerHealth.onDamageTaken -= drawPlayerHealth;
        PlayerHealth.onStart -= drawPlayerHealth;
        EnemyHealth.onEnemyKilled -= drawPlayerScore;
    }

    public void drawPlayerScore(EnemyHealth enemyHealth)
    {
        scoreText.text = GameStateManager.Instance.score.ToString();
    }

    public void drawPlayerHealth(PlayerHealth playerHealth)
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
