using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueRunner runner;
    public void SculptureDialogue()
    {
        Debug.Log("Start Sculpture Dialogue");
        runner.StartDialogue("Sculpture");
    }

    public void CocreatingDialogue()
    {
        runner.StartDialogue("Cocreating1");
    }

    public void CaringDialogue()
    {
        runner.StartDialogue("Caring1");
    }
}
