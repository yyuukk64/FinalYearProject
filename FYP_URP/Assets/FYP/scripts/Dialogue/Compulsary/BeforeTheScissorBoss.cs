using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeforeTheScissorBoss : MonoBehaviour
{
    protected PlayerMovement m_movement;
    protected PauseMenuManager m_pauseMenu;
    protected TriggerTheStoryAndBattle m_trigger;

    public Dialogue dialogue;

    protected string[] myName;
    protected string[] mySentences;
    protected int emotion;
    protected int sentencesNo = 0;


    [Header("UI")]
    public Text dialogueText;
    public Text nameText;

    [Space()]
    public Image Memoria;
    public Image Angel;
    public Image Devid;

    [Header("Animation")]
    public Animator anim;

    // Start is called before the first frame update
    protected void Start()
    {

        m_movement = FindObjectOfType<PlayerMovement>();
        m_pauseMenu = FindObjectOfType<PauseMenuManager>();
        m_trigger = FindObjectOfType<TriggerTheStoryAndBattle>();

        m_movement.canMove = false;
        m_pauseMenu.CanPause = false;

        myName = dialogue.dialoguerName;
        mySentences = dialogue.dialoguerSentences;
        emotion = dialogue.dialoguerEmotion[0];
    }

    protected void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && sentencesNo < mySentences.Length)
        {
            dialogueText.text = mySentences[sentencesNo];
            nameText.text = myName[sentencesNo];
            emotion = dialogue.dialoguerEmotion[sentencesNo];

            anim.SetInteger("SentanceNo", sentencesNo);
            if (myName[sentencesNo] == "Memoria")
            {
                Memoria.sprite = Memoria.GetComponent<CharacterEmotion>().illustrat[emotion];
                anim.SetTrigger("_Memoria");
            }
            else if (myName[sentencesNo] == "Angel")
            {
                Angel.sprite = Angel.GetComponent<CharacterEmotion>().illustrat[emotion];
                anim.SetTrigger("_Angel");
            }
            else if (myName[sentencesNo] == "Devid")
            {
                Devid.sprite = Devid.GetComponent<CharacterEmotion>().illustrat[emotion];
                anim.SetTrigger("_Devid");
            }

            sentencesNo++;
        }
        else if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0)) && sentencesNo == mySentences.Length)
        {
            endOftheAnimation();
        }
    }

    public void endOftheAnimation()
    {
        m_movement.canMove = true;
        m_pauseMenu.CanPause = true;
        m_trigger.EnterBossBattle();
    }
}
