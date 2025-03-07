using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.UI;
using Yarn.Unity;

public class ItemCollectionView : DialogueViewBase
{
    [SerializeField] DialogueRunner runner;
    [SerializeField] Image itemImage;
    private List<Sprite> sprites = new List<Sprite>();

    private void Awake()
    {
        runner.AddCommandHandler<string>("Item", GetItem);

        itemImage.enabled = false;

        Debug.Log("Loading item Sprites:");
        string[] guids1 = AssetDatabase.FindAssets("t:sprite", new[] { "Assets/Art/Items" });

        foreach (string guid1 in guids1)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
            sprites.Add((Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid1), typeof(Sprite)));
        }

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

        //iterate over list of sprites to find one that matches itemName
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].name == itemName)
            {
                print(itemName);
                var current_item_sprite = sprites[i];
                itemImage.sprite = current_item_sprite;
            }
        }
        //put collected item in inventory
    }
    public void onDialogueEnd()
    {
        itemImage.enabled = false;
    }
}
