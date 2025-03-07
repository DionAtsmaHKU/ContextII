using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] string eventName;
    private bool player_present = false;

    public UnityEvent onTriggerDialogue;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player_present = true;
            Debug.Log("player entered dialoguetrigger");
            //show button prompt to start dialogue
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player_present = false;
            Debug.Log("player exited dialoguetrigger");
            //hide button prompt
        }
    }

    private void Update()
    {
        if (player_present == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
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
