using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactionsobject : MonoBehaviour
{
    [SerializeField] private string interactionText = "Im an interactible object";
    public UnityEvent Oninteract = new UnityEvent();
    private void OnEnable()
    {

    }
    public string GetInteractionText()
    {
        return interactionText;
    }
    public void Interact()
    {
        Oninteract.Invoke();
    }

}
