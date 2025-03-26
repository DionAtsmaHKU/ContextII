using System;
using UnityEngine;

[Serializable]
public class InteractPrompt
{
    [SerializeField] GameObject UI;

    public void ShowPrompt()
    {
        UI.SetActive(true);
    }

    public void HidePrompt()
    {
        if (UI != null) UI.SetActive(false);
        //UI.SetActive(false);
    }
}
