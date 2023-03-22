using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawnEffect : MonoBehaviour
{
    [SerializeField] GameObject _Soul;
    [SerializeField] GameObject Spawn_Effect;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Spawn_Effect, _Soul.transform.position, Quaternion.identity);
    }
}
