using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Header("Cloud")]
    [SerializeField] private GameObject cloudObj;
    private int _cloudDmg;
    [SerializeField] private float _cloudAttckTimer;
    [SerializeField] private int _cloudAttckTimerStart;
    [SerializeField] private Text _cloudAttckTimerTxt;

    [Header("Barret")]
    [SerializeField] private GameObject barretObj;
    private int _barretDmg;
    [SerializeField] private float _barretAttckTimer;
    [SerializeField] private int _barretAttckTimerStart;
    [SerializeField] private Text _barretAttckTimerTxt;

    [Header("Crab")]
    [SerializeField] private GameObject crabObj;
    private int _crabDmg;

    private int _turnCounter;

    /*private void Start()
    {
        _cloudAttckTimer = _cloudAttckTimerStart;
        _barretAttckTimer = _barretAttckTimerStart;
    }*/

    private void Update()
    {
        _cloudAttckTimerTxt.text = "Time: " + _cloudAttckTimer;
        _barretAttckTimerTxt.text = "Time: " + _barretAttckTimer;

        if (_turnCounter == 2)
        {
            CrabAttack();
        }
    }

    private void FixedUpdate()
    {
        if(_cloudAttckTimer > 0)
        {
            _cloudAttckTimer -= Time.deltaTime;
        }

        if(_barretAttckTimer > 0)
        {
            _barretAttckTimer -= Time.deltaTime;
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
        if(_cloudAttckTimer <= 0)
        {
            _cloudDmg = Random.Range(89, 95);

            CloudHealth cloudHealth = cloudObj.GetComponent<CloudHealth>();
            CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();

            cloudHealth.shouldMove = 1;

            yield return new WaitForSeconds(.5f);

            crabHealth.health -= _cloudDmg;

            cloudHealth.shouldMove = 0;

            _turnCounter += 1;

            _cloudAttckTimer = _cloudAttckTimerStart;
        }
    }

    IEnumerator BarretAttacking()
    {
        if(_barretAttckTimer <= 0)
        {
            _barretDmg = Random.Range(33, 36);

            CrabHealth crabHealth = crabObj.GetComponent<CrabHealth>();
            BarretHealth barretHealth = barretObj.GetComponent<BarretHealth>();

            barretHealth.shouldMove = 1;

            yield return new WaitForSeconds(.5f);

            crabHealth.health -= _barretDmg;

            barretHealth.shouldMove = 0;

            _turnCounter += 1;

            _barretAttckTimer = _barretAttckTimerStart;
        }
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
