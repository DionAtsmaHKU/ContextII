using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] string eventName;
    public InteractPrompt prompt = new InteractPrompt();
    private bool player_present = false;

    public UnityEvent onTriggerDialogue;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player_present = true;
            Debug.Log("player entered dialoguetrigger");
            prompt.ShowPrompt();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player_present = false;
            Debug.Log("player exited dialoguetrigger");
            prompt.HidePrompt();
        }
    }

    private void Update()
    {
        if (player_present == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                prompt.HidePrompt();
                TriggerDialogue();
            }
        }
    }

    private void TriggerDialogue()
    {
        Debug.Log("Lets talk to / about:" + eventName);
        //send event with dialogue identifyer (string name)
        onTriggerDialogue.Invoke();
    }
}
