using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private interactablePromptUI interactablePromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private Interactable interactable;

    // Update is called once per frame
    private void Update()
    {
        
        
            numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius,
            colliders, interactableMask);

            if (numFound > 0)
            {
                interactable = colliders[0].GetComponent<Interactable>();

                if (interactable != null)
                {
                    if (!interactablePromptUI.IsDisplayed) interactablePromptUI.Setup(interactable.InteractionPrompt);
                    
                    if (Keyboard.current.eKey.wasPressedThisFrame)
                        interactable.Interact(interactor: this);

                }
            }
        
        else
        {
            if (interactable != null) interactable = null;
            if (interactablePromptUI.IsDisplayed) interactablePromptUI.Close();
        }
        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);

    }
}
