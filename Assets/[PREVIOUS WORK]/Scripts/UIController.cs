using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider livesDisplay;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseButton;

    //[SerializeField] Slider streakSlider;
    //[SerializeField] TextMeshPro streakText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        livesDisplay.value = PlayerDamage.livesRemaining;
        if(PlayerDamage.livesRemaining <= 0)
        {
            pauseButton.SetActive(false);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void ContinueTime()
    {
        pauseButton.SetActive(true);
        gameOverScreen.SetActive(false);
        PlayerDamage.livesRemaining = 3;
        Time.timeScale = 1;
    }
}
