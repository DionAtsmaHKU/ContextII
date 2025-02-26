using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Tooltip
{
    public TextMeshProUGUI testText;

    public void EnableTT()
    {
        testText.enabled = true;
    }

    public void DisableTT()
    {
        testText.enabled = false;
    } 
}
