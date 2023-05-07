using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ScissorPattern : MonoBehaviour
{
    Attack attack;
    BattleMNG_Boss_GetScissor BMNG;

    bool CD;    //is in Cool Down?

    // Start is called before the first frame update
    void Start()
    {
        attack = FindObjectOfType<Attack>();
        BMNG = FindObjectOfType<BattleMNG_Boss_GetScissor>();
        Pattern4();
    }

    // Update is called once per frame
    void Update()
    {
        if (!BMNG.isWin && !CD && !BMNG.isLost)
        {
            StartCoroutine(RandomAttackPattern(Random.RandomRange(0, 5)));
            Debug.Log("Fire!!!");
        }
    }

    void Pattern1()
    {
        attack.BeamAttack_V(Random.RandomRange(0, 9));
        attack.BeamAttack_V(Random.RandomRange(0, 9));
        attack.BeamAttack_H(Random.RandomRange(0, 7));
    }

    void Pattern2()
    {
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.BeamAttack_H(Random.RandomRange(0, 7));
        attack.BeamAttack_H(Random.RandomRange(0, 7));
        attack.BeamAttack_H(Random.RandomRange(0, 7));
    }
    void Pattern3()
    {
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.FireAreaAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
    }

    void Pattern4()     //¤«Beam
    {
        attack.FireAreaAttack();
        attack.FireAreaAttack();
    }

    IEnumerator RandomAttackPattern(int rnd)
    {
        CD = true;

        switch (rnd)
        {
            case 1:
                Pattern1();
                break;
            case 2:
                Pattern2();
                break;
            case 3:
                Pattern3();
                break;
            case 4:
                Pattern4();
                break;
        }

        yield return new WaitForSeconds(3);
        CD = false;
    }
}
