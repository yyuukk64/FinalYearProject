using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] GameObject _Player;

    // Start is called before the first frame update
    public void Init()
    {
        //Init
        Debug.Log("b");
        _Player = GameObject.FindWithTag("Player");
        _Player.transform.position = new Vector3(0, 1.53f, -70);
        _Player.GetComponent<PlayerManager>().LoadOnSceneLoaded();
        _Player.GetComponent<PlayerManager>().health = _Player.GetComponent<PlayerManager>().maxHealth;
    }
}
