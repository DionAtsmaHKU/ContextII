using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ToggleMinigame : MonoBehaviour
{
    [SerializeField] Camera camA;
    [SerializeField] Camera camB;
    [SerializeField] GameObject minigameObjects;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject sculpture;
    [SerializeField] GameObject inventoryParent;
    [SerializeField] GameObject tooltip;
    // [SerializeField] DialogueRunner runner;
    public bool inGame;
    public int currentPage = 1;

    public List<Item> sculptList = new List<Item>();
    public List<Item> inventory = new List<Item>();
    public List<Transform> itemSlots = new List<Transform>();

    private void Start()
    {
        // runner.AddCommandHandler<string>("HasItem", HasItem);
    }

    public void Toggle()
    {
        if (inGame) 
        {
            SwapItemParents();
            SetYarnVariables();

            minigameObjects.SetActive(false);
            platform.SetActive(true);
            tooltip.SetActive(false);
            camA.enabled = !camA.enabled;
            camB.enabled = !camA.enabled;
            HasItem();
            inGame = false;
        }
        else
        {
            OpenInventory(1);

            minigameObjects.SetActive(true);
            platform.SetActive(false);
            tooltip.SetActive(true);
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

        // Debug.Log("start: " + startIndex + ", end: " + endIndex);

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

    /*
    public void HasItem(string itemName)
    {
        foreach(Item item in inventory)
        {
            if (item.name == itemName)
            {
                if (sculptList.Contains(item))
                {
                    return;
                }
                inventory.Remove(item);
                if (itemName == "Shard")
                {
                    Debug.Log("Set HasShard to True");
                    VariableManager.Instance.SetYarnBool("$HasShard", true);
                }
                else if (itemName == "Rabbit")
                {
                    VariableManager.Instance.SetYarnBool("$HasRabbit", true);
                }
                else if (itemName == "Petition")
                {
                    VariableManager.Instance.SetYarnBool("$HasPetition", true);
                }
            }
        }
        return;
    }
    */

    public void HasItem()
    {
        foreach (Item item in inventory)
        {
            if (item.name == "Shard")
            {
                Debug.Log("Set HasShard to True");
                VariableManager.Instance.SetYarnBool("$HasShard", true);
                if (inGame && !sculptList.Contains(item))
                {
                    Debug.Log("Set HasShard t FALSE");
                    VariableManager.Instance.SetYarnBool("$HasShard", false);
                }
            }
            else if (item.name == "Rabbit")
            {
                Debug.Log("Set HasRabbit to True");
                VariableManager.Instance.SetYarnBool("$HasRabbit", true);
                if (inGame && !sculptList.Contains(item))
                {
                    Debug.Log("Set HasRabbit to False");
                    VariableManager.Instance.SetYarnBool("$HasRabbit", false);
                }
            }
            else if (item.name == "Petition")
            {
                VariableManager.Instance.SetYarnBool("$HasPetition", true);
                if (inGame && !sculptList.Contains(item))
                {
                    VariableManager.Instance.SetYarnBool("$HasPetition", false);
                }
            }
        }
        return;
    }

    private void SetYarnVariables()
    {
        VariableManager.Instance.SetYarnFloat("$LearningStat", Sculpture.Instance.impactScore.learning);
        VariableManager.Instance.SetYarnFloat("$ImaginingStat", Sculpture.Instance.impactScore.imagining);
        VariableManager.Instance.SetYarnFloat("$EmbodyingStat", Sculpture.Instance.impactScore.embodying);
        VariableManager.Instance.SetYarnFloat("$CaringStat", Sculpture.Instance.impactScore.caring);
        VariableManager.Instance.SetYarnFloat("$OrganisingStat", Sculpture.Instance.impactScore.organizing);
        VariableManager.Instance.SetYarnFloat("$InspiringStat", Sculpture.Instance.impactScore.inspiring);
        VariableManager.Instance.SetYarnFloat("$CocreatingStat", Sculpture.Instance.impactScore.cocreating);
        VariableManager.Instance.SetYarnFloat("$EmpoweringStat", Sculpture.Instance.impactScore.empowering);
        VariableManager.Instance.SetYarnFloat("$SubvertingStat", Sculpture.Instance.impactScore.subverting);
        VariableManager.Instance.SetYarnFloat("$TotalStat", Sculpture.Instance.impactScore.Total());

        //float test = VariableManager.Instance.GetYarnFloat("$SubvertingStat");
        //Debug.Log(test);
    }
}
