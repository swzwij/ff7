using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudHealth : MonoBehaviour
{
    [Header("Health")]
    public int health;
    public Text healthTXT;

    
    [Header("pik")]
    [SerializeField] private int cum;
    public Vector3 monkey;
    public Camera monkeystreams;
    public int fortnite;
    

    [Header("Pos")]
    public Vector3 AttackPos;
    public Vector3 IdlePos;
    public int shouldMove;

    private void Update()

    
    {
        healthTXT.text = "Cloud: " + health;

        if(shouldMove == 0)
        {
            transform.position = IdlePos;
        }
        else if(shouldMove == 1)
        {
            transform.position = AttackPos;
        }
    }
}
