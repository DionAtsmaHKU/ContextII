using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private bool in_dialogue = false;
    public bool Interact = false;

    public UnityEvent onInteract;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (in_dialogue == false) 
            {
                onInteract.Invoke();
                Interact = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Interact = false;
        }
    }

    public void onDialogueStart()
    {
        in_dialogue = true;
    }

    public void onDialogueEnd()
    {
        in_dialogue = false;
    }
}
