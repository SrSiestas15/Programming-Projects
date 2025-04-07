using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StreakManager : MonoBehaviour
{
    Slider streakSlider;
    TextMeshProUGUI streakText;

    private static bool streakActive;
    private static int currentStreak = 0;

    private static float streakTimer;

    [Space] public float defaultStreakTime; //time the player has to get a kill after getting 1 kill
    private static float currentStreakTime; //time the player has to get a kill to keep up the streak

    public float speedUpRate; //rate the timer gets faster with each increase to the streak
    private static float speedUpRateStatic;

    // Start is called before the first frame update
    void Start()
    {
        streakSlider = GetComponentInChildren<Slider>();
        streakText = GetComponentInChildren<TextMeshProUGUI>();

        currentStreakTime = defaultStreakTime;
        speedUpRateStatic = speedUpRate;
    }

    // Update is called once per frame
    void Update()
    {
        streakText.text = currentStreak.ToString();
        streakSlider.value = streakTimer;
        streakSlider.maxValue = currentStreakTime;

        if (streakActive)
        {
            streakTimer -= Time.deltaTime;
            
            if (streakTimer <= 0)
            {
                //streak OVER
                streakTimer = 0;
                currentStreakTime = defaultStreakTime;
                currentStreak = 0;
                streakActive = false;
            }
        }
    }

    public static void GotElimination()
    {
        if (!streakActive)
        {
            //start streak
            currentStreak = 1;
            streakTimer = currentStreakTime;
            streakActive = true;
        }
        else
        {
            //increase streak
            currentStreak++;
            currentStreakTime = currentStreakTime * speedUpRateStatic;
            streakTimer = currentStreakTime;
        }
    }


}
