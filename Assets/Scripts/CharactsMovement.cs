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

    // Footstep sound variables
   public AudioSource audioSource;
public float footstepDelay = 0.5f;
private float footstepTimer = 1f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        staminaSystem = GetComponent<StaminaSystem>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        AddMoveInput(forwardInput, rightInput);

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && staminaSystem.UseStamina(20f * Time.deltaTime);

        float currentSpeed = isRunning ? runSpeed : MoveSpeed;

        MoveDirection.Normalize();
        MoveDirection.y = -1f;

        characterController.Move(MoveDirection * currentSpeed * Time.deltaTime);

        HandleWalkingSound();


    }

public void AddMoveInput(float forwardInput, float rightInput)
{
    if (forwardInput == 0f && rightInput == 0f)
    {
        MoveDirection = Vector3.zero;
        return;
    }

    Vector3 forward = Camera.main.transform.forward;
    Vector3 right = Camera.main.transform.right;

    forward.y = 0f;
    right.y = 0f;

    forward.Normalize();
    right.Normalize();

    MoveDirection = (forwardInput * forward) + (rightInput * right);
}


void HandleWalkingSound()
{
    bool isGrounded = characterController.isGrounded;
    bool isMoving = MoveDirection.magnitude <1f;

    if (isGrounded && isMoving)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    else
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}



   
}
