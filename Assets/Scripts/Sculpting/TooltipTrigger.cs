using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    public string title;
    public string description;
    private DragNPlaceItem dragNPlaceItem;

    private float timer = 0;

    private void Start()
    {
        dragNPlaceItem = GetComponent<DragNPlaceItem>();
    }

    private void Update()
    {
        if (dragNPlaceItem.dragging)
        {
            TooltipSystem.Hide();
            timer = 1;
        }

    }

    private void OnMouseOver()
    {
        timer -= Time.deltaTime;
        if (timer <  0 && dragNPlaceItem.toggle.inGame)
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
