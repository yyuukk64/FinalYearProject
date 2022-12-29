using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogueBox : MonoBehaviour
{
    public static bool inDialogue = false;
    public GameObject Dialogue;

    public void NPCInteract1()
    {
        if (inDialogue == false)
        {
            Dialogue.SetActive(true);
            Time.timeScale = 0f;
            inDialogue = true;
        }
        else
        {
            Dialogue.SetActive(false);
            Time.timeScale = 1f;
            inDialogue = false;
        }
    }
}                


