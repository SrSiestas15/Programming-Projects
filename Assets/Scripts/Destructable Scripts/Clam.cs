using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clam : MonoBehaviour
{
    private TakeDamage enemyScript;
    bool animPlayed = false;
    Animation spawnPearlAnimation;
    Animator clamAnimator;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = gameObject.GetComponent<TakeDamage>();
        clamAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.health <= 0 && !animPlayed)
        {
            Debug.Log("health below 0");
            clamAnimator.Play("spawnPearl");
            animPlayed = true;

        }
    }
}
