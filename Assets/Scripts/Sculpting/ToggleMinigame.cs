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
    [SerializeField] GameObject inventoryParent;
    public bool inGame;

    public List<Item> inventory = new List<Item>();
    public List<Transform> itemSlots = new List<Transform>();

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
            OpenInventory();

            minigameObjects.SetActive(true);
            platform.SetActive(false);
            camA.enabled = !camA.enabled;
            camB.enabled = !camA.enabled;
            inGame = true;
        }
    }

    private void OpenInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].inPlace)
                continue;
            inventory[i].transform.position = itemSlots[i].transform.position;
        }
    }

    private void SwapItemParents()
    {
        Sculpture.Instance.itemScores.Clear();
        foreach (var item in inventory)
        {
            if (item.inPlace)
            {
                item.gameObject.transform.parent = sculpture.transform;
                Sculpture.Instance.itemScores.Add(item.impactScore);
            } 
            else
            {
                item.gameObject.transform.parent = inventoryParent.transform;
            }
        }
        Sculpture.Instance.UpdateScore();
    }
}
