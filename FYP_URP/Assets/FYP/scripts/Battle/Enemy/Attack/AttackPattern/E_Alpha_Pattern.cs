using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Alpha_Pattern : MonoBehaviour
{
    Attack attack;
    BattleMNG BMNG;

    bool CD;    //is in Cool Down?

    // Start is called before the first frame update
    void Start()
    {
        attack = FindObjectOfType<Attack>();
        BMNG = FindObjectOfType<BattleMNG>();
        Pattern4();
    }

    // Update is called once per frame
    void Update()
    {
        if (!BMNG.isWin && !CD &&!BMNG.isLost)
        {
            StartCoroutine(RandomAttackPattern(Random.RandomRange(0, 5)));
            Debug.Log("Fire!!!");
        }
    }

    void Pattern1()
    {
        attack.BeamAttack_V(Random.RandomRange(0, 7));
        attack.BeamAttack_H(Random.RandomRange(0, 7));
    }

    void Pattern2()
    {
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.BeamAttack_H(Random.RandomRange(0, 9));
        attack.BeamAttack_H(Random.RandomRange(0, 9));
        attack.BeamAttack_H(Random.RandomRange(0, 7));
    }
    void Pattern3()
    {
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
        attack.IncinerateSpellAttack();
    }

    void Pattern4()     //¤«Beam
    {
        attack.BeamAttack_V(3);
        attack.BeamAttack_V(4);
        attack.BeamAttack_V(5);
        attack.BeamAttack_H(2);
        attack.BeamAttack_H(3);
        attack.BeamAttack_H(4);
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
