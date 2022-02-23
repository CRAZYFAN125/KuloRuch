using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayoutInSettings : MonoBehaviour
{
    [SerializeField]private GameObject[] panelsToSwitch;
    private int index = 0;

    public void ChangePanels()
    {
        if (index <= panelsToSwitch.Length -1)
        {
            panelsToSwitch[index].SetActive(false);
            index++;
            panelsToSwitch[index].SetActive(true);
        }
        else
        {
            panelsToSwitch[index].SetActive(false);
            index = 0;
            panelsToSwitch[index].SetActive(true);
        }
    }
}
