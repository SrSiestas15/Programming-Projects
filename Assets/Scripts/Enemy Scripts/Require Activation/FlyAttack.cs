using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class FlyAttack : EnemyActivate
{
    //FlyType enum definition
    public enum FlyType { bartender, gunslinger};
    [Space(5)]
    [Header("Fly Type")]
    public FlyType type;

    //sprite renderer variables
    SpriteRenderer spriteRenderer;
    public static Sprite bartenderSprite;
    public static Sprite gunslingerSprite;

    //projectile variables
    [Space(5)]
    [Header("Projectile Variables")]
    public GameObject bottlePrefab;
    public GameObject bulletPrefab;
    public float projectileInterval;
    private float projectileTimer;
    public float gunslingerShootAngle;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //get sprite files from the resources folder
        bartenderSprite = Resources.Load<Sprite>("Sprites/temp_fly_bartender");
        gunslingerSprite = Resources.Load<Sprite>("Sprites/temp_fly_gunslinger"); 


        if (type == FlyType.bartender)
        {
            spriteRenderer.sprite = bartenderSprite; //set sprite to bartender
        } 
        else if (type == FlyType.gunslinger)
        {
            spriteRenderer.sprite = gunslingerSprite; //set sprite to gunslinger
        }

    }

    void Update()
    {
        if (active)
        {
            if (type == FlyType.bartender)
            {
                //bartender attack
                projectileTimer += Time.deltaTime;
                if (projectileTimer >= projectileInterval)
                {
                    Instantiate(bottlePrefab, transform.position, transform.rotation);
                    projectileTimer = 0f;
                }
            }
            else if (type == FlyType.gunslinger)
            {
                projectileTimer += Time.deltaTime;
                if (projectileTimer >= projectileInterval)
                {
                    //gunslinger attack
                    GameObject bullet1 = Instantiate(bulletPrefab, transform.position, transform.rotation); //instantiate bullet
                    MoveDirection bullet1Script = bullet1.GetComponent<MoveDirection>(); //get move script
                    bullet1Script.runDirection = new Vector2(-1 * Mathf.Cos(Mathf.Deg2Rad * gunslingerShootAngle), Mathf.Sin(Mathf.Deg2Rad * gunslingerShootAngle)); //set move direction to specified angle

                    GameObject bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    MoveDirection bullet2Script = bullet2.GetComponent<MoveDirection>();
                    bullet2Script.runDirection = new Vector2(-1 * Mathf.Cos(Mathf.Deg2Rad * gunslingerShootAngle), -1 * Mathf.Sin(Mathf.Deg2Rad * gunslingerShootAngle));

                    projectileTimer = 0f;
                }
            }

        }
    }
}
