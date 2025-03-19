using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    public string title;
    public string description;

    private void OnMouseOver()
    {
        TooltipSystem.Show(description, title);
    
    }

    private void OnMouseExit()
    {
        TooltipSystem.Hide();
    }
}
