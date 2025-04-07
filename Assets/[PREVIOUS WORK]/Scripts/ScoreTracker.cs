using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static int ScenePoints;
    public static int EnemyPoints;
    public int currentPoints;
    public static int LevelDeaths;
    public int numberOfDeaths;


    // Start is called before the first frame update
    void Start()
    {
        EnemyPoints = 0;
        ScenePoints = 0;
        LevelDeaths = 0;
        SetPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        currentPoints = ScenePoints;
        numberOfDeaths = LevelDeaths;
    }

    public static void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt("CurrentEP", EnemyPoints);
        PlayerPrefs.SetInt("CurrentSP", ScenePoints);
        PlayerPrefs.SetInt("CurrentDeaths", LevelDeaths);

    }
}
