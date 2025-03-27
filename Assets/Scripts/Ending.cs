using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Yarn.Unity;

public class Ending : DialogueViewBase
{
    [SerializeField] DialogueRunner runner;
    [SerializeField] GameObject endingCanvas;
    [SerializeField] List<TextMeshProUGUI> textTitles;
    [SerializeField] List<TextMeshProUGUI> textBoxes;
    [SerializeField] List<Image> textImages;
    [SerializeField] CustomTextDictionary textList;
    [SerializeField] CustomSpriteDictionary spriteList;
    private Dictionary<string, string> texts;
    private Dictionary<string, Sprite> sprites;
    Dictionary<string, int> topThree = new Dictionary<string, int>();

    private void Start()
    {
        runner.AddCommandHandler("End", EndGame);
        texts = textList.ToDictionary();
        sprites = spriteList.ToDictionary();
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            EndGame();
        }
        */
    }

    public void EndGame()
    {
        Dictionary<string, int> allScores = ScoresToDictionary();
        
        int i = 0;
        foreach (var item in allScores.OrderByDescending(key => key.Value))
        {
            if (i > 2)
            {
                break;
            }
            topThree.Add(item.Key, item.Value);
            i++;
        }

        foreach (var item in topThree)
        {
            Debug.Log(item.Key);
        }

        SetEndScreen();
        endingCanvas.SetActive(true);
    }

    private Dictionary<string, int> ScoresToDictionary()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>();
        scores.Add("Learning", Sculpture.Instance.impactScore.learning);
        scores.Add("Embodying", Sculpture.Instance.impactScore.embodying);
        scores.Add("Imagining", Sculpture.Instance.impactScore.imagining);
        scores.Add("Caring", Sculpture.Instance.impactScore.caring);
        scores.Add("Organizing", Sculpture.Instance.impactScore.organizing);
        scores.Add("Inspiring", Sculpture.Instance.impactScore.inspiring);
        scores.Add("Co-creating", Sculpture.Instance.impactScore.cocreating);
        scores.Add("Empowering", Sculpture.Instance.impactScore.empowering);
        scores.Add("Subverting", Sculpture.Instance.impactScore.subverting);
        return scores;
    }

    private void SetEndScreen()
    {
        int i = 0;
        foreach (var item in topThree)
        {
            Debug.Log(texts[item.Key]);
            textTitles[i].text = item.Key;
            textBoxes[i].text = texts[item.Key];
            textImages[i].sprite = sprites[item.Key];
            i++;
        }
    }
}

[Serializable]
public class CustomTextDictionary
{
    [SerializeField] List<CustomDictionaryText> items;

    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string, string> newDict = new Dictionary<string, string>();

        foreach (CustomDictionaryText item in items)
        {
            newDict.Add(item.name, item.text);
        }
        return newDict;
    }
}

[Serializable]
public class CustomDictionaryText
{
    [SerializeField] public string name;
    [SerializeField] public string text;
}

[Serializable]
public class CustomSpriteDictionary
{
    [SerializeField] List<CustomDictionarySprite> items;

    public Dictionary<string, Sprite> ToDictionary()
    {
        Dictionary<string, Sprite> newDict = new Dictionary<string, Sprite>();

        foreach (CustomDictionarySprite item in items)
        {
            newDict.Add(item.name, item.sprite);
        }
        return newDict;
    }
}

[Serializable]
public class CustomDictionarySprite
{
    [SerializeField] public string name;
    [SerializeField] public Sprite sprite;
}
