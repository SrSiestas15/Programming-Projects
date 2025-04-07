using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndPlay : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseText;

    public void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseText.SetActive(true);
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
            pauseText.SetActive(false);
        }
    }

}
