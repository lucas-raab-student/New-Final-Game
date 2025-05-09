using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Objective : MonoBehaviour
{
    [SerializeField] private string ObjectiveText = "Iam an Onjective";
    [SerializeField] private string CompltedText = "Wooooo";
    public UnityEvent OnCompleteObj = new UnityEvent();
    [SerializeField] private Text objdisplay;
    private void OnEnable()
    {
        objdisplay.text = ObjectiveText;
    }
    public void CompleteObjective()
    {
        if (gameObject.activeSelf)
        {
            objdisplay.text = "";
            OnCompleteObj.Invoke();
            gameObject.SetActive(false);
        }

    }
}
