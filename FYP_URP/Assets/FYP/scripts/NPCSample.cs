using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSample : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public GameObject dialogue;
    public string InteractionPrompt { get => prompt; }
    public bool Interact(Interactor interactor)
        
        //what the interact do
    {
        Debug.Log(message: DialogueBox.inDialogue);

            dialogue.GetComponent<DialogueBox>().NPCInteract1();
        Debug.Log(message: DialogueBox.inDialogue);
        Debug.Log(message: "Hello World");
        return true;
    }
}
