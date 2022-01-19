using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("Cloud")]
    [SerializeField] private GameObject cloudObj;
    [SerializeField] private int _cloudDmg;

    [Header("Barret")]
    [SerializeField] private GameObject barretObj;
    [SerializeField] private int _barretDmg;

    [Header("Crab")]
    [SerializeField] private GameObject crabObj;
    [SerializeField] private int _crabDmg;

    [Header("Turns")]
    [SerializeField] private int _turnCounter;

    private void Update()
    {
        if(_turnCounter == 2)
        {
            CrabAttack();
        }
    }

    public void CloudAttack()
    {
        CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();
        CloudHealth cloudHealth = cloudObj.GetComponent<CloudHealth>();

        crabHealth.health -= _cloudDmg;

        _turnCounter += 1;
    }

    public void BarretAttack()
    {
        _barretDmg = Random.Range(33, 36);

        CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();
        BarretHealth barretHealth = barretObj.GetComponent<BarretHealth>();

        crabHealth.health -= _barretDmg;

        _turnCounter += 1;
    }

    private void CrabAttack()
    {
        CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();
        CloudHealth cloudHealth = cloudObj.GetComponent<CloudHealth>();
        BarretHealth barretHealth = barretObj.GetComponent<BarretHealth>();

        cloudHealth.health -= _crabDmg;
        barretHealth.health -= _crabDmg;

        _turnCounter = 0;
    }
}
