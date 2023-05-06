using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    PauseAndResume PAR;
    CanvasController_Takara canvasController;
    Answer answer;
    PlayerMovment pm;

    [SerializeField] GameObject[] Displayer;

    string a, b, c, d, e, f;
    string EnteredAns;
    string ans;

    [SerializeField] GameObject takara;

    private void Start()
    {
        PAR = PauseAndResume.FindObjectOfType<PauseAndResume>();
        answer = Answer.FindObjectOfType<Answer>();
        canvasController = CanvasController_Takara.FindObjectOfType<CanvasController_Takara>();
        pm = PlayerMovment.FindObjectOfType<PlayerMovment>();
        ans = takara.GetComponent<Answer>().answer;
        
    }
    void Correct()
    {
        //Do someting...
        PAR.resume();
        takara.GetComponent<CanvasController_Takara>().PasswordEntering_Canvas.SetActive(false);
        takara.GetComponent<CanvasController_Takara>().solved = true;

        //Correct SoundEffect...
    }

    void Incorrect()
    {
        //Do something...

        //Incorrect SoundEffect...
    }

    public void AnswerCheck()
    {
        MakeAns(Displayer.Length);

        if (EnteredAns == ans)
        {
            Debug.Log("Correct!");
            Correct();
            
        }
        else
        {
            Debug.Log("Incorrect!");
            Incorrect();
            EnteredAns = "";
        }
    }

    void MakeAns(int NumberOfDigits)
    {
        for (int i = 0; i < NumberOfDigits ; i++)
        {
            switch (i)
            {
                case 0:
                    a = Displayer[i].GetComponent<PasswordControl>().entering;
                    EnteredAns += a;
                    break;
                case 1:
                    b = Displayer[i].GetComponent<PasswordControl>().entering;
                    EnteredAns += b;
                    break;
                case 2:
                    c = Displayer[i].GetComponent<PasswordControl>().entering;
                    EnteredAns += c;
                    break;
                case 3:
                    d = Displayer[i].GetComponent<PasswordControl>().entering;
                    EnteredAns += d;
                    break;
                case 4:
                    e = Displayer[i].GetComponent<PasswordControl>().entering;
                    EnteredAns += e;
                    break;
                case 5:
                    f = Displayer[i].GetComponent<PasswordControl>().entering;
                    EnteredAns += f;
                    break;
            }
        }
    }

    
}
