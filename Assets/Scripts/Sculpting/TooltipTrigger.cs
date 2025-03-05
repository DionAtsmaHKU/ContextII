using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    public string title;
    public string description;
    private Item item;

    private float timer = 0;

    private void Start()
    {
        item = GetComponent<Item>();
    }

    private void Update()
    {
        if (item.dragging)
        {
            TooltipSystem.Hide();
            timer = 1;
        }

    }

    private void OnMouseOver()
    {
        timer -= Time.deltaTime;
        if (timer <  0 && item.toggle.inGame)
        {
            TooltipSystem.Show(description, title);
        }
    }

    private void OnMouseExit()
    {
        TooltipSystem.Hide();
        timer = 1;
    }
}
