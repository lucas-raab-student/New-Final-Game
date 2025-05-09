using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    FirstPersonCamera fristPersonCamera;
    CharactsdMovement charcterMovement;
   
    // Start is called before the first frame update
    void Start()
    {
        fristPersonCamera = GetComponent<FirstPersonCamera>();
        charcterMovement = GetComponent<CharactsdMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
        HandleMoveInput();
    }
    void HandleCameraInput()
    {
        fristPersonCamera.AddAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        fristPersonCamera.AddyaxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);

    }
    void HandleMoveInput()
    {
        float fowardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");
    
        charcterMovement.AddMoveInput(fowardInput, rightInput);
    }
}
