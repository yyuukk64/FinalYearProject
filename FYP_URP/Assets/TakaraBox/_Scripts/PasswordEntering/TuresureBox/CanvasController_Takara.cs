using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController_Takara : MonoBehaviour
{
    //  For the GUI which is appearing when player is looking at the obj.
    //  Please assign the same obj into tfm_GUI and GUI                        
    [SerializeField] Transform tfm_GUI;
    [SerializeField] GameObject gui;
    [SerializeField] GameObject Self;

    [SerializeField] public GameObject PasswordEntering_Canvas;

    private bool CanOpen = false;
    public bool solved = false;
    public bool Opened = false;

    //Script Acctechment
    MouseLook mouseLook;
    PauseAndResume PAR;
    PlayerMovment pm;

    void Start()
    {
        mouseLook = MouseLook.FindObjectOfType<MouseLook>();
        PAR = PauseAndResume.FindObjectOfType<PauseAndResume>();
        pm = PlayerMovment.FindObjectOfType<PlayerMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        //Let the GUI follow the Rotation of player view
        float mouseX = Input.GetAxis("Mouse X") * mouseLook.mouseSensitivity * Time.deltaTime;
        tfm_GUI.Rotate(Vector3.up * mouseX);


        //The method which is open the Canvas
        //===== You can fell free to change it=======
        if (CanOpen && !solved && Input.GetKeyDown(KeyCode.Mouse0))
        {
            open();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Opened)
        {
            close();
        }
    }
    public void close()
    {
        Debug.Log(PasswordEntering_Canvas.name);
        PasswordEntering_Canvas.SetActive(false);
        Opened = false;
        pm.Opened = false;
        PAR.resume();
    }

    public void open()
    {
        Debug.Log(PasswordEntering_Canvas.name);
        PasswordEntering_Canvas.SetActive(true);
        Opened = true;
        pm.Opened = true;
        PAR.OpenCanvas();
    }

    

    private void OnMouseEnter()
    {
        if (!solved && !pm.Opened)
        {
            gui.SetActive(true);
            CanOpen = true;
            //Do Something
        }
    }

    private void OnMouseExit()
    {
        gui.SetActive(false);
        CanOpen = false;
        //Do Something
    }
}
