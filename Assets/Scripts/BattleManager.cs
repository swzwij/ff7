using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("Cloud")]
    [SerializeField] private GameObject cloudObj;
    private int _cloudDmg;

    [Header("Barret")]
    [SerializeField] private GameObject barretObj;
    private int _barretDmg;

    [Header("Crab")]
    [SerializeField] private GameObject crabObj;
    private int _crabDmg;

    private int _turnCounter;

    private void Update()
    {
        if(_turnCounter == 2)
        {
            CrabAttack();
        }
    }

    public void CloudAttack()
    {
        StartCoroutine(CloudAttacking());
    }

    public void BarretAttack()
    {
        StartCoroutine(BarretAttacking());
    }

    private void CrabAttack()
    {
        StartCoroutine(CrabAttacking());
    }

    IEnumerator CloudAttacking()
    {
        _cloudDmg = Random.Range(89, 95);

        CloudHealth cloudHealth = cloudObj.GetComponent<CloudHealth>();
        CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();

        cloudHealth.shouldMove = 1;

        yield return new WaitForSeconds(.5f);
        
        crabHealth.health -= _cloudDmg;

        cloudHealth.shouldMove = 0;

        _turnCounter += 1;
    }

    IEnumerator BarretAttacking()
    {
        _barretDmg = Random.Range(33, 36);

        CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();
        BarretHealth barretHealth = barretObj.GetComponent<BarretHealth>();

        barretHealth.shouldMove = 1;

        yield return new WaitForSeconds(.5f);

        crabHealth.health -= _barretDmg;

        barretHealth.shouldMove = 0;

        _turnCounter += 1;
    }

    IEnumerator CrabAttacking()
    {
        _turnCounter = 0;

        yield return new WaitForSeconds(1f);

        _crabDmg = Random.Range(16, 23);

        CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();
        CloudHealth cloudHealth = cloudObj.GetComponent<CloudHealth>();
        BarretHealth barretHealth = barretObj.GetComponent<BarretHealth>();

        crabHealth.shouldMove = 1;

        yield return new WaitForSeconds(.5f);

        cloudHealth.health -= _crabDmg;
        barretHealth.health -= _crabDmg;

        crabHealth.shouldMove = 0;
    }
}
