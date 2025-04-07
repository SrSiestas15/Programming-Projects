using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPowerBar : MonoBehaviour
{
    public static float power;
    public float powerLevel;
    public int barCost;
    public static int powerPerBar;

    [SerializeField] float powerDisplay;

    public GameObject miniShip1;
    public GameObject miniShip2;

    [SerializeField]  float startingBulletFrequency;

    void Start()
    {
        power = 0;
        powerPerBar = barCost;

        startingBulletFrequency = PlayerMoveAndShoot.bulletFrequency;
    }

    void Update()
    {

        powerDisplay = power;

        if (power >= (barCost * 1) && powerLevel == 0)
        {
            //ONE FULL BAR
            powerLevel = 1;
            PlayerMoveAndShoot.bulletFrequency = startingBulletFrequency/2;
            miniShip1.SetActive(false);
            miniShip2.SetActive(false);
        }
        else if (power >= (barCost * 2) && powerLevel == 1)
        {
            //TWO FULL BARS
            //ADD FIRST MINI GUY
            powerLevel = 2;
            miniShip1.SetActive(true);
            miniShip2.SetActive(false);
            
        }
        else if (power >= (barCost * 3) && powerLevel == 2)
        {
            //THREE FULL BARS
            //ADD SECOND MINI GUY
            powerLevel = 3;
            miniShip1.SetActive(true);
            miniShip2.SetActive(true);
        }

    }
    
    private void OnSpecialAttack()
    {
        Debug.Log("special attxk");
        if(power >= barCost)
        {
            power -= barCost;


            if (power <= 0)
            {
                powerLevel = 0;
                PlayerMoveAndShoot.bulletFrequency = startingBulletFrequency;
                miniShip1.SetActive(false);
                miniShip2.SetActive(false);
            }
            if (power == barCost * 1)
            {
                powerLevel = 1;
                miniShip1.SetActive(false);
                miniShip2.SetActive(false);
            }
            if (power == barCost * 2)
            {
                powerLevel = 2;
                miniShip2.SetActive(false);
            }
        }
    }

}
