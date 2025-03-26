using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.UI;
using Yarn.Unity;
using System.Drawing.Text;
using System;
using UnityEngine.Assertions.Must;

public class ItemCollectionView : DialogueViewBase
{
    [SerializeField] DialogueRunner runner;
    [SerializeField] Image itemImage;
    private Dictionary<string, Sprite> itemSprites = new Dictionary<string, Sprite>();
    [SerializeField] CustomDictionary itemList;
    private Dictionary<string, Item> allItems = new Dictionary<string, Item>();
    [SerializeField] ToggleMinigame minigameManager;

    private void Awake()
    {
        allItems = itemList.ToDictionary();
        runner.AddCommandHandler<string>("Item", GetItem);
        runner.AddCommandHandler<string>("RemoveItem", RemoveItem);

        itemImage.enabled = false;

        Debug.Log("Loading item Sprites:");

        Sprite[] sprites = Resources.LoadAll<Sprite>("Items");
        foreach (Sprite s in sprites)
        {
            itemSprites.Add(s.name, s);
        }

        //string[] guids1 = AssetDatabase.FindAssets("t:sprite", new[] { "Assets/Art/Items" });

        //foreach (string guid1 in guids1)
        //{
        //Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
        //sprites.Add((Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid1), typeof(Sprite)));
        //}

        foreach (Sprite item in sprites)
        {
            Debug.Log(item.name);
        }

        Debug.Log("Done Loading Items");
    }

    private void GetItem(string itemName)
    {
        if (itemImage.enabled == false)
        {
            itemImage.enabled = true;
        }

        print("give item: ");
        minigameManager.inventory.Add(allItems[itemName]);
        minigameManager.HasItem();

        print(itemName);
        var current_item_sprite = itemSprites[itemName];
        itemImage.sprite = current_item_sprite;

        //put collected item in inventory
    }

    private void RemoveItem(string itemName)
    {
        print("remove item: ");
        
        minigameManager.inventory.Remove(allItems[itemName]);
        if (minigameManager.sculptList.Contains(allItems[itemName]))
        {
            minigameManager.sculptList.Remove(allItems[itemName]);
        }
        
        Destroy(allItems[itemName].gameObject);
        VariableManager.Instance.SetYarnBool("$Has" + itemName, false);
        print(itemName);
    }

    public void onDialogueEnd()
    {
        itemImage.enabled = false;
    }
}

[Serializable]
public class CustomDictionary
{
    [SerializeField] List<CustomDictionaryItem> items;
        
    public Dictionary<string, Item> ToDictionary()
    {
        Dictionary<string, Item> newDict = new Dictionary<string, Item>();

        foreach (CustomDictionaryItem item in items)
        {
            newDict.Add(item.name, item.item);
        }
        return newDict;
    }
}

[Serializable]
public class CustomDictionaryItem
{
    [SerializeField] public string name;
    [SerializeField] public Item item;
}