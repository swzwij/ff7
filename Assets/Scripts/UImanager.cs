using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject cloudAttackWindow;
    public GameObject barretAttackWindow;

    public void OpenCloudAttackWindow()
    {
        cloudAttackWindow.SetActive(true);
    }

    public void CloseCloudAttackWindow()
    {
        cloudAttackWindow.SetActive(false);
    }

    public void OpenBarretAttackWindow()
    {
        barretAttackWindow.SetActive(true);
    }

    public void CloseBarretAttackWindow()
    {
        barretAttackWindow.SetActive(false);
    }
}
