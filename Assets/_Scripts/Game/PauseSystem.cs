using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public static bool GameIsPaused = false;

    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    void Resume()
    {
        UIManager.Instance.pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        UIManager.Instance.pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
