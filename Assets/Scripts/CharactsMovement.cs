using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactsdMovement : MonoBehaviour
{
    CharacterController characterController;
    public float MoveSpeed = 5f;        // Walking speed
    public float runSpeed = 10f;        // Running speed
    private Vector3 MoveDirection;
    private StaminaSystem staminaSystem;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        staminaSystem = GetComponent<StaminaSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detect input for movement
        float forwardInput = Input.GetAxis("Vertical");  // W/S or Arrow Up/Down
        float rightInput = Input.GetAxis("Horizontal");  // A/D or Arrow Left/Right


        // Add movement input (calculated in the method below)
        AddMoveInput(forwardInput, rightInput);

        // Check if the player is holding down shift (to run)
        bool isRunning = Input.GetKey(KeyCode.LeftShift)&& staminaSystem.UseStamina(20f*Time.deltaTime);

      

        // Set the speed based on whether we're running or walking
        float currentSpeed = isRunning ? runSpeed : MoveSpeed;

        // Normalize direction and apply gravity
        MoveDirection.Normalize();
        MoveDirection.y = -1f;  // Apply gravity to keep the player grounded

        // Move the character using CharacterController
        characterController.Move(MoveDirection * currentSpeed * Time.deltaTime);
    }

    // Method to calculate movement direction based on input
    public void AddMoveInput(float forwardInput, float rightInput)
    {
        // Get the direction based on the camera
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        // Zero out the y-axis so the character only moves on the x/z plane
        forward.y = 0f;
        right.y = 0f;

        // Normalize the directions to prevent faster diagonal movement
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on user input and camera orientation
        MoveDirection = (forwardInput * forward) + (rightInput * right);
    }
}
