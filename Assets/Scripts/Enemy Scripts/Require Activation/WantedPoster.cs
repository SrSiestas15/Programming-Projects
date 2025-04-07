using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WantedPoster : EnemyActivate
{
    //PosterPose enum definition
    public enum PosterPose { vertical, horizontal, diagonal}
    public PosterPose pose;

    //sprite renderer variables
    SpriteRenderer spriteRenderer;
    public static Sprite verticalSprite;
    public static Sprite horizontalSprite;
    public static Sprite diagonalSprite;

    //projectile variables
    public GameObject bulletPrefab;
    public float projectileInterval;
    private float projectileTimer;
    public float diagonalAngle;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        //get sprite files from the resources folder
        verticalSprite = Resources.Load<Sprite>("Sprites/temp_wanted_poster_vertical");
        horizontalSprite = Resources.Load<Sprite>("Sprites/temp_wanted_poster_horizontal");
        diagonalSprite = Resources.Load<Sprite>("Sprites/temp_wanted_poster_diagonal"); 

        //activates sprites for the different gun poses
        if (pose == PosterPose.vertical)
        {
            spriteRenderer.sprite = verticalSprite;
        } 
        else if (pose == PosterPose.horizontal)
        {
            spriteRenderer.sprite = horizontalSprite;
        } 
        else if (pose == PosterPose.diagonal) 
        {
            spriteRenderer.sprite = diagonalSprite;
        }

    }


    void Update()
    {
        if (active)
        {
            if (pose == PosterPose.vertical) //if vertical pose shoot vertically
            {
                projectileTimer += Time.deltaTime;
                if (projectileTimer >= projectileInterval)
                {
                    //shoot one bullet vertically
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //instantiate bullet
                    MoveDirection bulletScript = bullet.GetComponent<MoveDirection>(); //get move script
                    bulletScript.runDirection = new Vector2(0, 1); //set move direction to vertical (up)

                    projectileTimer = 0f;
                }
            }
            else if (pose == PosterPose.horizontal) //if horixontal pose shoot horizontally
            {
                projectileTimer += Time.deltaTime;
                if (projectileTimer >= projectileInterval)
                {
                    //shoot one bullet horizontally
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); //instantiate bullet
                    MoveDirection bulletScript = bullet.GetComponent<MoveDirection>(); //get move script
                    bulletScript.runDirection = new Vector2(-1, 0); //set move direction to horizontal (left)

                    projectileTimer = 0f;
                }
            }
            else if (pose == PosterPose.diagonal) //if diagonal pose shoot diagonally
            {
                projectileTimer += Time.deltaTime;
                if (projectileTimer >= projectileInterval)
                {
                    //shoot two bullets diagonally
                    GameObject bullet1 = Instantiate(bulletPrefab, transform.position, transform.rotation); //instantiate bullet
                    MoveDirection bullet1Script = bullet1.GetComponent<MoveDirection>(); //get move script
                    bullet1Script.runDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * diagonalAngle), Mathf.Sin(Mathf.Deg2Rad * diagonalAngle)); //set move direction to specified angle

                    GameObject bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
                    MoveDirection bullet2Script = bullet2.GetComponent<MoveDirection>();
                    bullet2Script.runDirection = new Vector2(-1 * Mathf.Cos(Mathf.Deg2Rad * diagonalAngle), Mathf.Sin(Mathf.Deg2Rad * diagonalAngle));

                    projectileTimer = 0f;
                }
            }

        }

    }
}
