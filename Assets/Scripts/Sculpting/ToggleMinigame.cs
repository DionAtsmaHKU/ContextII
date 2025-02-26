using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMinigame : MonoBehaviour
{
    [SerializeField] Camera camA;
    [SerializeField] Camera camB;
    [SerializeField] GameObject minigameObjects;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject sculpture;
    [SerializeField] GameObject inventory;
    [SerializeField] List<DragNPlaceItem> items;
    public bool inGame;

    public void Toggle()
    {
        if (inGame) 
        {
            SwapItemParents();

            minigameObjects.SetActive(false);
            platform.SetActive(true);
            camA.enabled = !camA.enabled;
            camB.enabled = !camA.enabled;
            inGame = false;
            
        }
        else
        {
            minigameObjects.SetActive(true);
            platform.SetActive(false);
            camA.enabled = !camA.enabled;
            camB.enabled = !camA.enabled;
            inGame = true;
        }
    }

    private void SwapItemParents()
    {
        Sculpture.Instance.itemScores.Clear();
        foreach (var item in items)
        {
            if (item.inPlace)
            {
                item.transform.parent = sculpture.transform;
                Sculpture.Instance.itemScores.Add(item.impactScore);
            } 
            else
            {
                item.transform.parent = inventory.transform;
            }
        }
        Sculpture.Instance.UpdateScore();
    }
}
