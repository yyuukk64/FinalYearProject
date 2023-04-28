using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchPlayer : MonoBehaviour
{
    PlayerMovement m_movement;
    PauseMenuManager m_pauseMenu;

    public Dialogue dialogue;

    private string[] myName;
    private string[] mySentences;
    private int sentencesNo = 0;

    [Header("UI")]
    public Text dialogueText;
    public Text nameText;

    [Header("Animation")]
    public Animator anim;

    private void Awake()
    {
        m_movement = FindObjectOfType<PlayerMovement>();
        m_pauseMenu = FindObjectOfType<PauseMenuManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_movement.canMove = false;
        m_pauseMenu.CanPause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sentencesNo < mySentences.Length)
        {
            dialogueText.text = mySentences[sentencesNo];
            nameText.text = myName[sentencesNo];
            sentencesNo++;


        }
    }
}
