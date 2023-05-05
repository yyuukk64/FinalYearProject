using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private PlayerMovement m_playerMovement;
    private PauseMenuManager m_pauseMenu;

    public Dialogue dialogue;

    [Space()]
    public GameObject canvas;
    public GameObject EBtn_Canvas;

    [Space()]
    public Text dialogueText;
    public Text nameText;

    [Header("World space Conversation bubble")]
    public GameObject ConvBubbleCanva;
    public Text worldDialogue;
    public bool isAllow = true;

    private string[] myName;
    private string[] mySentences;
    private int emotion;
    private int sentencesNo = 0;

    private bool talking = false;
    private bool taked = false;

    [Header("Animation")]
    public Animator anim;

    public Image Memoria;
    public Image NPC;

    // Start is called before the first frame update
    private void Start()
    {
        m_playerMovement = FindObjectOfType<PlayerMovement>();
        m_pauseMenu = FindObjectOfType<PauseMenuManager>();

        //EBtn_Canvas.SetActive(false);
        
        myName = dialogue.dialoguerName;
        mySentences = dialogue.dialoguerSentences;
        emotion = dialogue.dialoguerEmotion[0];

        //assign the last sentence of the conversation and show in world space
        worldDialogue.text = dialogue.dialoguerSentences[dialogue.dialoguerSentences.Length - 1];
    }

    // Update is called once per frame
    private void Update()
    {
        if (talking && Input.GetKeyDown(KeyCode.E)&& sentencesNo < mySentences.Length)
        {
            EBtn_Canvas.SetActive(false);
            m_playerMovement.canMove = false;
            m_pauseMenu.CanPause = false;
            canvas.SetActive(true);
            dialogueText.text = mySentences[sentencesNo];
            nameText.text = myName[sentencesNo];
            emotion = dialogue.dialoguerEmotion[sentencesNo];

            if (myName[sentencesNo] == "Memoria")
            {
                Memoria.sprite = Memoria.GetComponent<CharacterEmotion>().illustrat[emotion];
                anim.SetTrigger("_Memoria");
            }
            else
            {
                NPC.sprite = NPC.GetComponent<CharacterEmotion>().illustrat[emotion];
                anim.SetTrigger("_NPC");
            }

            sentencesNo++;
        }
        else if (talking && Input.GetKeyDown(KeyCode.E) && sentencesNo == mySentences.Length)
        {
            m_playerMovement.canMove = true;
            m_pauseMenu.CanPause = true;
            //EBtn_Canvas.SetActive(true);
            canvas.SetActive(false);
            talking = false;
            taked = true;
            ConvBubbleCanva.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger success!");
        if(other.tag == "Player" && !taked)
        {
            EBtn_Canvas.SetActive(true);
            talking = true;
            sentencesNo = 0;
        }

        if (other.tag == "Player" && taked)
        {
            ConvBubbleCanva.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EBtn_Canvas.SetActive(false);
            canvas.SetActive(false);
            talking = false;
            ConvBubbleCanva.SetActive(false);
        }
    }
}
