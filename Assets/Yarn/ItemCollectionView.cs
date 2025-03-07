using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ItemCollectionView : DialogueViewBase
{
    [SerializeField] DialogueRunner runner;

    private void Awake()
    {
        runner.AddCommandHandler<string>("Item", GetItem);
    }

    private void GetItem(string itemName)
    {
        //find and display collected item
        //show collected item
        //put collected item in inventory
    }
}
