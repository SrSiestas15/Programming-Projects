using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public static bool canAbility; //whether the player has enough stamina to do the ability
    public static float abilityCost; //how much stamina is needed to use an ability

    [SerializeField]
    private Slider staminaSlider; //UI slider that displays current stamina

    [SerializeField]
    private float setAbilityCost; //used in inspector to assign the costs of abilities
    
    [SerializeField]
    private float maxStamina; //max stamina
    public static float currentStamina; //player's current stamina

    [SerializeField]
    private float recoverySpeed; //speed at which stamina recovers

    public static float attackRecoverySpeed = .2f; //speed at which stamina recovers while shooting

    void Start()
    {
        //begin with max amount of stamina
        currentStamina = maxStamina;

        if (staminaSlider != null)
        {
            //sets max value of slider to match variable
            staminaSlider.maxValue = maxStamina;
        }

        //uses the public values of a Vector2 to assign the cost of each ability

        abilityCost = setAbilityCost;

        //ADD CHANGE OF COLOUR TO BAR WHEN READY TO USE
    }

    void Update()
    {
        Mathf.Clamp(currentStamina,0, maxStamina);

        if(staminaSlider != null)
        {
            //updates UI slider to display current stamina amount
            staminaSlider.value = currentStamina;
        }

        //checks if there's enough stamina for ability to be activated
        if (currentStamina > abilityCost)
        {
            canAbility = true;
        }
        else canAbility = false;
        
        currentStamina += recoverySpeed * Time.deltaTime;
        Mathf.Clamp(currentStamina, 0, maxStamina);
    }
}
