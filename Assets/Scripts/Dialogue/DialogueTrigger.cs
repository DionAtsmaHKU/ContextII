using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] string eventName;
    [SerializeField] GameObject InputManager;
    [SerializeField] bool SelfDestruct = false;
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

    public void TriggerDialogue()
    {
        if (player_present == true)
        {
            prompt.HidePrompt();
            Debug.Log("Lets talk to / about:" + eventName);
            onTriggerDialogue.Invoke();

            if (SelfDestruct == true)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
