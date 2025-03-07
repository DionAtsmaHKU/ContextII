using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.UI;
using Yarn.Unity;

public class CharacterPortraits : DialogueViewBase
{
    [SerializeField] DialogueRunner runner;
    [SerializeField] Image portraitImage;
    public List<Sprite> sprites = new List<Sprite>();

    void Awake()
    {
        portraitImage.enabled = false;

        runner.AddCommandHandler<string>("Act", SetActor); //yarn command for setting character sprite / portrait

        Debug.Log("Loading NPC Sprites:");
        string[] guids1 = AssetDatabase.FindAssets("t:sprite", new[] { "Assets/Art/Sprites" });

        foreach (string guid1 in guids1)
        {
            //Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
            sprites.Add((Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid1), typeof(Sprite)));
        }

        foreach (Sprite npc in sprites)
        {
            Debug.Log(npc.name);
        }

        Debug.Log("Done Loading");
    }

    public void SetActor(string actorName)
    {
        if (portraitImage.enabled == false)
        {
            portraitImage.enabled = true;
        }

        print("set actor to:");

        //iterate over list of sprites to find one that matches actorName
        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].name == actorName)
            {
                print(actorName);
                var current_actor_sprite = sprites[i];
                portraitImage.sprite = current_actor_sprite;
            }
        }
    }

    public void onDialogueEnd()
    {
        portraitImage.enabled = false;
    }
}