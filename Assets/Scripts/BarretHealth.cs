using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarretHealth : MonoBehaviour
{
    [Header("Health")]
    public int health;
    public Text healthTXT;
    public Slider healthSlider;

    [Header("Pos")]
    public Vector3 AttackPos;
    public Vector3 IdlePos;
    public int shouldMove;

    public float speed;

    private void Update()
    {
        healthTXT.text = health + " / 321";
        healthSlider.value = health;

        if (shouldMove == 0)
        {
            transform.position = IdlePos;
        }
        else if (shouldMove == 1)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, AttackPos, step);
            transform.position = AttackPos;
        }
    }
}
