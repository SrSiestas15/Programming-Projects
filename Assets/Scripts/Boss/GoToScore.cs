using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScore : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float numOfExplosions;
    [SerializeField] int unlockLevel;
    public enum unlockables { none, dash, parry, health, stamina};
    [SerializeField] unlockables unlock;
    

    private TakeDamage healthScript;
    private SpriteRenderer sprite;
    private Vector3 explosionPos;

    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<TakeDamage>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        explosionPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthScript.health <= 0 && !started)
        {
            StartCoroutine("FlashRed");
            healthScript.StopAllCoroutines();
            healthScript.enabled = false;
            UnlockAbility(unlock);
            started = true;
        }
    }

    IEnumerator FlashRed()
    {
        for(int i = 0; i <= 5; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(.2f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(.2f);
        }
        sprite.enabled = false;
        StartCoroutine("Explosions");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Explosions()
    {
        for(int i = 0; i <= numOfExplosions; i++)
        {
            explosionPos.x = transform.position.x + Random.Range(-2, 2);
            explosionPos.y = transform.position.y + Random.Range(-2, 2);
            Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
            yield
            return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(1f);
        ScoreTracker.SetPlayerPrefs();

        if(unlockLevel == 2 && !LevelController.lvl2Unlocked)
        {
            LevelController.lvl2Unlocked = true;
        }
        else if (unlockLevel == 3 && !LevelController.lvl3Unlocked)
        {
            LevelController.lvl3Unlocked = true;
        }

        SceneManager.LoadScene("Score Scene");
    }

    void UnlockAbility(unlockables ability)
    {
        if (ability == unlockables.dash)
        {
            PlayerMoveAndShoot.dashUnlocked = true;
        }
    }
}
