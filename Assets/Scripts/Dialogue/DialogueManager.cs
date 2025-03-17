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

    public void GrassDialogue()
    {
        runner.StartDialogue("Grass");
    }

    public void CocreatingDialogue()
    {
        runner.StartDialogue("Cocreating1");
    }

    public void CaringDialogue()
    {
        runner.StartDialogue("Caring1");
    }

    public void EmbodyingDialogue()
    {
        runner.StartDialogue("Embodying1");
    }
    public void EmpoweringDialogue()
    {
        runner.StartDialogue("Empowering1");
    }

    public void SubvertingDialogue()
    {
        runner.StartDialogue("Subverting1");
    }

    public void ImaginingDialogue()
    {
        runner.StartDialogue("Imagining1");
    }
    public void InspiringDialogue()
    {
        runner.StartDialogue("Inspiring1");
    }
}
