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
        UI.SetActive(false);
    }
}
