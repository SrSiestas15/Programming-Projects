using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject lvl2Button;
    [SerializeField] GameObject lvl3Button;

    public static bool lvl2Unlocked;
    public static bool lvl3Unlocked;

    // Start is called before the first frame update
    void Start()
    {
        if(lvl2Button == null || lvl3Button == null)
        {
            return;
        }
        else
        {
            if (lvl2Unlocked)
            {
                lvl2Button.SetActive(true);
            } else lvl2Button.SetActive(false);

            if (lvl3Unlocked)
            {
                lvl3Button.SetActive(true);
            }
            else lvl3Button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
