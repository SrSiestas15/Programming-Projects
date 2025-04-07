using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounters;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounters.text = $"Deaths: {PlayerPrefs.GetInt("CurrentDeaths")} \nEnemy Points: {PlayerPrefs.GetInt("CurrentEP")} \nStage Points: {PlayerPrefs.GetInt("CurrentSP")}";
    }
}
