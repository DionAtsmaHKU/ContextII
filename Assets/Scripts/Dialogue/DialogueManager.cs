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

    public void ShardDialogue()
    {
        runner.StartDialogue("Shard");
    }

    public void WateringCanDialogue()
    {
        runner.StartDialogue("WateringCan");
    }

    public void CanvasDialogue()
    {
        runner.StartDialogue("Canvas");
    }

    public void MegaphoneDialogue()
    {
        runner.StartDialogue("Megaphone");
    }

    public void KaleidoscopeDialogue()
    {
        runner.StartDialogue("Kaleidoscope");
    }

    public void DrawingDialogue()
    {
        runner.StartDialogue("Drawing");
    }

    public void MirrorDialogue()
    {
        runner.StartDialogue("Mirror");
    }

    public void CocreatingDialogue()
    {
        runner.StartDialogue("CocreatingDialogue");
    }

    public void CaringDialogue()
    {
        runner.StartDialogue("CaringDialogue");
    }

    public void EmbodyingDialogue()
    {
        runner.StartDialogue("EmbodyingDialogue");
    }
    public void EmpoweringDialogue()
    {
        runner.StartDialogue("EmpoweringDialogue");
    }

    public void SubvertingDialogue()
    {
        runner.StartDialogue("SubvertingDialogue");
    }

    public void ImaginingDialogue()
    {
        runner.StartDialogue("ImaginingDialogue");
    }
    public void InspiringDialogue()
    {
        runner.StartDialogue("InspiringDialogue");
    }

    public void OrganisingDialogue()
    {
        runner.StartDialogue("OrganisingDialogue");
    }

    public void LearningDialogue()
    {
        runner.StartDialogue("LearningDialogue");
    }
}
