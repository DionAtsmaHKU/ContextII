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
    private Dictionary<string, Sprite> portraitSprites = new Dictionary<string, Sprite>();

    void Awake()
    {
        portraitImage.enabled = false;

        runner.AddCommandHandler<string>("Act", SetActor); //yarn command for setting character sprite / portrait

        Debug.Log("Loading NPC Sprites:");

        Sprite[] sprites = Resources.LoadAll<Sprite>("NPCs"); 
        foreach (Sprite s in sprites)
        {
            portraitSprites.Add(s.name, s);
        }

        //string[] guids1 = AssetDatabase.FindAssets("t:sprite", new[] { "Assets/Art/NPCs" });

        //foreach (string guid1 in guids1)
        //{
        //Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
        //sprites.Add((Sprite)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid1), typeof(Sprite)));
        //}

        foreach (Sprite npc in sprites)
        {
        Debug.Log(npc.name);
        }

        Debug.Log("Done Loading NPC's");
    }

    public void SetActor(string actorName)
    {
        if (portraitImage.enabled == false)
        {
            portraitImage.enabled = true;
        }

        print("set actor to:");

        print(actorName);
        var current_actor_sprite = portraitSprites[actorName];
        portraitImage.sprite = current_actor_sprite;

    }

    public void onDialogueEnd()
    {
        portraitImage.enabled = false;
    }
}