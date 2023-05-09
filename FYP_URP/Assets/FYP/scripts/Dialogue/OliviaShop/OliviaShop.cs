using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OliviaShop : MonoBehaviour
{
    private PlayerMovement m_playerMovement;
    private PauseMenuManager m_pauseMenu;

    public Dialogue dialogue;
    public Dialogue ShopDialogue;

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
    private bool talked = false;
    private bool Close = false;

    [Header("Animation")]
    public Animator anim;

    public Image Memoria;
    public Image NPC;

    public GameObject CanvasShop;

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
        worldDialogue.text = "Welcome! Memoria";
    }

    // Update is called once per frame
    private void Update()
    {

        if (talking && Input.GetKeyDown(KeyCode.E) && sentencesNo < mySentences.Length && !talked)
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
        else if (talking && Input.GetKeyDown(KeyCode.E) && sentencesNo == mySentences.Length && !talked)
        {
            m_playerMovement.canMove = true;
            m_pauseMenu.CanPause = true;
            //EBtn_Canvas.SetActive(true);
            canvas.SetActive(false);
            talking = false;
            talked = true;
            ConvBubbleCanva.SetActive(true);
        }

        if (talking && Input.GetKeyDown(KeyCode.E) && sentencesNo == 1 && talked)
        {
            canvas.SetActive(false);
            CanvasShop.SetActive(true);
        }
        else if (talking && Input.GetKeyDown(KeyCode.E) && sentencesNo < mySentences.Length && talked)
        {
            EBtn_Canvas.SetActive(false);
            m_playerMovement.canMove = false;
            m_pauseMenu.CanPause = false;
            canvas.SetActive(true);
            dialogueText.text = mySentences[sentencesNo];
            nameText.text = myName[sentencesNo];
            emotion = ShopDialogue.dialoguerEmotion[sentencesNo];

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

        if (Close && Input.GetKeyDown(KeyCode.E))
        {
            m_playerMovement.canMove = true;
            m_pauseMenu.CanPause = true;
            //EBtn_Canvas.SetActive(true);
            canvas.SetActive(false);
            talking = false;
            talked = true;
            ConvBubbleCanva.SetActive(true);
            Close = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger success!");
        if (other.tag == "Player" && !talked)
        {
            EBtn_Canvas.SetActive(true);
            talking = true;
            sentencesNo = 0;
        }

        if (other.tag == "Player" && talked)
        {
            ConvBubbleCanva.SetActive(true);
            EBtn_Canvas.SetActive(true);
            talking = true;
            sentencesNo = 0;

            myName = ShopDialogue.dialoguerName;
            mySentences = ShopDialogue.dialoguerSentences;
            emotion = ShopDialogue.dialoguerEmotion[0];
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

    public void CloseShop()
    {
        CanvasShop.SetActive(false);
        canvas.SetActive(true);

        sentencesNo++;

        dialogueText.text = mySentences[sentencesNo];
        nameText.text = myName[sentencesNo];
        emotion = ShopDialogue.dialoguerEmotion[sentencesNo];

        NPC.sprite = NPC.GetComponent<CharacterEmotion>().illustrat[emotion];
        anim.SetTrigger("_NPC");
        Close = true;
    }
}
