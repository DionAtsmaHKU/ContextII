using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private bool inDialogue = false;

    public UnityEvent onInteract;
    public static event Action OnInteract;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inDialogue) 
            {
                OnInteract.Invoke();
                //onInteract.Invoke();
            }
        }
    }

    public void onDialogueStart()
    {
        inDialogue = true;
    }

    public void onDialogueEnd()
    {
        inDialogue = false;
    }
}
