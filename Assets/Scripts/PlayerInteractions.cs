using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private Text InteractableName;
    private Interactionsobject targetInteraction;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        string interactionText = "";

        targetInteraction = null;


        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<Interactionsobject>();
        }


        if (targetInteraction && targetInteraction.enabled)
        {
            interactionText = targetInteraction.GetInteractionText();
        }

        SetInteractibleNameText(interactionText);
    }

    private void SetInteractibleNameText(string newText)
    {
        if (InteractableName)
        {
            InteractableName.text = newText;
        }
    }
    public void TryInteract()
    {
        if (targetInteraction && targetInteraction.enabled)
        {
            targetInteraction.Interact();
        }
    }
}
