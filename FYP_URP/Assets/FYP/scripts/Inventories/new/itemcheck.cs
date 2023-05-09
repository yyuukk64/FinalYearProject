using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemcheck : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject Player;
    [SerializeField] int array;
    void Awake()
    {
        playerManager = Player.GetComponent<PlayerManager>();
    }
    public TMP_Text number;
    

    // Update is called once per frame
    void Update()
    {
        string textVariable = "x" + playerManager.Consumables[array];
        number.text = textVariable;
    }
}
