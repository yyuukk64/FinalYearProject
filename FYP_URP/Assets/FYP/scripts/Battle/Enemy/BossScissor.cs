using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScissor : GeneralEnemy
{
    BattleMNG_Boss_GetScissor BMNG;

    // Start is called before the first frame update
    void Start()
    {
        BMNG = FindObjectOfType<BattleMNG_Boss_GetScissor>();
        _Player = BMNG._Player;
        BMNG._Enemy = _Enemy;
        m_soulPooling = FindObjectOfType<SoulPooling>();
        Initially();
    }
}
