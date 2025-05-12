using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    [Header("Stamina Values")]
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10f;
    public float staminaRegenDelay = 2f;
    public float LastStaminaUseTime;

    [Header("UI")]
    public Slider staminaRegen; // Assign your slider in the inspector

    void Start()
    {
        currentStamina = maxStamina;

        // Optional: Initialize the UI bar
        if (staminaRegen != null)
        {
            staminaRegen.maxValue = maxStamina;
            staminaRegen.value = currentStamina;
        }
    }

    void Update()
    {
        // Regenerate stamina after delay
        if (Time.time > LastStaminaUseTime + staminaRegenDelay && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
        }

        // Update UI bar
        if (staminaRegen != null)
        {
            staminaRegen.value = currentStamina;
        }
    }

    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
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
        LastStaminaUseTime = Time.time;
    }
}
