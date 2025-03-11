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
    public int currentPage = 1;

    public List<Item> sculptList = new List<Item>();
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
            OpenInventory(1);

            minigameObjects.SetActive(true);
            platform.SetActive(false);
            camA.enabled = !camA.enabled;
            camB.enabled = !camA.enabled;
            inGame = true;
        }
    }

    public void OpenInventory(int page)
    {
        if (page <= 0 || page > 5)
            return;

        currentPage = page;
        foreach (var item in inventory)
        {
            if (!item.inPlace && !sculptList.Contains(item))
            {
                sculptList.Add(item);
            }
        }

        foreach (var item in sculptList)
        {
            if (item.inPlace)
                continue;
            item.gameObject.SetActive(false);
        }

        int startIndex = 0 + (page-1) * 6;
        int endIndex = sculptList.Count;
        if (endIndex > page * 6)
        {
            endIndex = page * 6;
        }

        Debug.Log("start: " + startIndex + ", end: " + endIndex);

        for (int i = startIndex; i < endIndex; i++)
        {
            if (sculptList[i].inPlace)
                continue;
            sculptList[i].transform.position = itemSlots[i%6].transform.position;
            sculptList[i].gameObject.SetActive(true);
        }
    }

    private void SwapItemParents()
    {
        Sculpture.Instance.itemScores.Clear();
        sculptList.Clear();
        foreach (var item in inventory)
        {
            if (item.inPlace)
            {
                item.gameObject.transform.parent = sculpture.transform;
                sculptList.Remove(item);
                Sculpture.Instance.itemScores.Add(item.impactScore);
            } 
            else
            {
                item.gameObject.transform.parent = inventoryParent.transform;
                sculptList.Add(item);
            }
        }
        Sculpture.Instance.UpdateScore();
    }
}
