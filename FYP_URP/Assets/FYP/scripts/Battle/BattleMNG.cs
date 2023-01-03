using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMNG : MonoBehaviour
{


    public GameObject _Player;
    [SerializeField] GameObject _Soul;

    [HideInInspector] public bool isWin = false;
    bool Waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWin && !Waiting)
        {
            StartCoroutine(SpawnNewSoul());
        }
    }

    IEnumerator SpawnNewSoul()
    {
        Waiting = true;
        yield return new WaitForSeconds(5);

        var position = new Vector3(Random.Range(-40.0f, 40.0f), 2, Random.Range(-30.0f, 30.0f));
        Instantiate(_Soul, position, Quaternion.identity);

        Waiting = false;
    }
}
