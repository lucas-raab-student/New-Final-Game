using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate=10f;
    public float staminaRegenDelay = 2f;
    public   float LastStaminaUseTime;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > LastStaminaUseTime + staminaRegenDelay && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;

            currentStamina = Mathf.Min(currentStamina, maxStamina);
        }
    }
    public bool UseStamina(float amount)
    { 
        if(currentStamina>=amount)
        {
            currentStamina -= amount;
            LastStaminaUseTime = Time.time;
            return true;

        }
        return false;
    }
    public void RefiillStamona(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Min(currentStamina, maxStamina);
        LastStaminaUseTime= Time.time;
    }
}
