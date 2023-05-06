using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndResume : MonoBehaviour
{
    public GameObject Move;
    MouseLook mouse;
    PlayerMovment pm;

     void Start()
    {
        mouse = FindObjectOfType<MouseLook>();
        pm = PlayerMovment.FindObjectOfType<PlayerMovment>();
    }

    public void Pause()         //Pause Time
    {
        Move.SetActive(false);
        mouse.mouseSensitivity = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        //Pause Menu()
        
    }

    public void OpenCanvas()    //Time Continue
    {
        Move.SetActive(false);
        pm.Opened = true;
        mouse.mouseSensitivity = 0f; 
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void resume()
    {
        Move.SetActive(true);
        pm.Opened = false;
        mouse.mouseSensitivity = 1500f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

