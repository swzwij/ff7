using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarretHealth : MonoBehaviour
{
    [Header("Health")]
    public int health;
    public Text healthTXT;

    private void Update()
    {
        healthTXT.text = "Barret: " + health;
    }
}
