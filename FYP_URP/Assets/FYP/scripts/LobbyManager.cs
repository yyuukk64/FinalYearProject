using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] GameObject _Player;

    // Start is called before the first frame update
    void Start()
    {
        //Init
        Debug.Log("b");
        _Player = GameObject.FindWithTag("Player");
        _Player.GetComponent<PlayerManager>().Init();
        _Player.GetComponent<PlayerManager>().LoadOnSceneLoaded();
        _Player.transform.position = new Vector3(0f, 1.53f, -70f);
        _Player.GetComponent<PlayerManager>().health = _Player.GetComponent<PlayerManager>().maxHealth;
    }
}
