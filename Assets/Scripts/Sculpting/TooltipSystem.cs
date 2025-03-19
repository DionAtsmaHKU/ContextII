using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using Yarn;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem current { get; private set; }
    public Tooltip tooltip;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (current != null && current != this)
        {
            Destroy(this);
        }
        else
        {
            current = this;
        }
    }

    public static void Show(string content, string header = "")
    {
        current.tooltip.SetText(content, header);
    }

    public static void Hide()
    {
        current.tooltip.SetText(" "," ");
    }
}
