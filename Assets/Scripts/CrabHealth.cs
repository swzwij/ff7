using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabHealth : MonoBehaviour
{
    [Header("Health")]
    public int health;
    public Text healthTXT;

    private void Update()
    {
        healthTXT.text = "Crab: " + health;

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        print("Crab Ded");
        Destroy(gameObject);
    }
}
