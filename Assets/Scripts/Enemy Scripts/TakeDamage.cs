using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health;
    public bool isTakingDamage = false;
    public float takingDamageTimer;
    float stopTakingDamageTimer = .1f;
    float flashingTime = .1f;

    public int setPoints;
    private string pointType;
    public GameObject FloatingTextPrefab; 

    SpriteRenderer enemySprite;
    bool isFlashing;

    Color normalColor;
    Color flashColor;

    [SerializeField] int numOfPowerPoints; //how many points the enemy should drop (set through inspector)
    [SerializeField] GameObject powerPoint; //the powerPoint prefab

    private Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        enemyRB = GetComponent<Rigidbody2D>();

        normalColor = new Color(0.9f, 0.9f, 0.9f);
        flashColor = new Color(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (gameObject.tag != "Special Action")
            {
                ShowPoints();
                if(gameObject.tag == "Enemy")
                {
                    ScoreTracker.EnemyPoints += setPoints;
                }
                else if(gameObject.tag == "Destructable")
                {
                    ScoreTracker.ScenePoints += setPoints;
                }
                SpawnPoints();

                if (gameObject.tag == "Enemy")
                {
                    //notify streak meter
                    StreakManager.GotElimination();
                }

                Destroy(gameObject);
            }
        }

        if (isTakingDamage)
        {
            takingDamageTimer += Time.deltaTime;
            //enemySprite.material = flashMaterial;
            if (isFlashing == false)
            {
                StartCoroutine("Flash");
            }

            if (takingDamageTimer >= stopTakingDamageTimer)
            {
                //enemySprite.material = normalMaterial;
                isTakingDamage = false;
                takingDamageTimer = 0;
            }
        }
    }

    public void TakeHit(float damage)
    {
        health -= damage;
        isTakingDamage = true;
        StaminaController.currentStamina += StaminaController.attackRecoverySpeed;
    }

    IEnumerator Flash()
    {
        isFlashing = true;
        enemySprite.color = flashColor;
        yield 
        return new WaitForSeconds(flashingTime);
        enemySprite.color = normalColor;
        yield
        return new WaitForSeconds(flashingTime);
        isFlashing = false;
    }

    void ShowPoints()
    {
        if (gameObject.tag == "Enemy")
        {
            pointType = "EP";
        } else if (gameObject.tag == "Destructable")
        {
            pointType = "SP";
        }
        TextMesh floatingText = FloatingTextPrefab.GetComponent<TextMesh>();
        floatingText.text = $"{setPoints}{pointType}";

        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
    }

    void SpawnPoints()
    {
        for(int i = 0; i < numOfPowerPoints; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), 0);
            Instantiate(powerPoint, transform.position + spawnPos, Quaternion.identity);
        }
    }
}