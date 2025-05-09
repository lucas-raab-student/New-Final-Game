using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    private float xAxis;
    private float yAxis;
    public float yAxisTurnRate = 360F;
    public float xAxisTurnRate = 360F;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame

    private void LateUpdate()
    {



        Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0F);

        Camera.main.transform.rotation = newRotation;
    }
    public void AddAxisInput(float input)
    {
        xAxis -= input * xAxisTurnRate;
        xAxis = Mathf.Clamp(xAxis, -90f, 90f);
    }
    public void AddyaxisInput(float input)
    {
        yAxis += input * yAxisTurnRate;
    }
}
