using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.UI;
using Yarn.Unity;

public class NPCPortraitsView : DialogueViewBase
{
    [SerializeField] DialogueRunner runner;

    [Header("Character Sprites")]
    [Tooltip("drag in all the NPC sprites / portraits here")]
    public GameObject Embodying, Learning, Imagining, Caring, Organizing, Inspiring, Cocreating, Empowering, Subverting;

    private List<GameObject> sprites = new List<GameObject>();
    private GameObject current_actor;

    void Awake()
    {
        runner.AddCommandHandler<string>("Act", SetActor); //yarn command for setting character sprite / portrait

        string[] guids1 = AssetDatabase.FindAssets("t:GameObject", new[] { "Assets/Sprites/PrefabSprites" });

        foreach (string guid1 in guids1)
        {
            Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
        }

        sprites.Add(Embodying);
        sprites.Add(Learning);
        sprites.Add(Imagining);
        sprites.Add(Caring);
        sprites.Add(Organizing);
        sprites.Add(Inspiring);
        sprites.Add(Cocreating);
        sprites.Add(Empowering);
        sprites.Add(Subverting);

    }

    public void SetActor(string actorName)
    {
        print("set actor to:");
        if (current_actor != null)
        {
            Destroy(current_actor);
        }

        //iterate over list of sprites to find one that matches actorName
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].name == actorName)
            {
                print(actorName);
                var current_actor_prefab = sprites[i];
                current_actor = Instantiate(current_actor_prefab);
            }
        }
    }
}