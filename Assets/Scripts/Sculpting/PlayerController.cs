using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ToggleMinigame toggleScript;
    [SerializeField] bool MovementEnabled = true;
    [SerializeField] MeshRenderer mr;
    public bool inSculptRange;
    private float sprintSpeed;
    [SerializeField] InteractPrompt prompt;

    private void Start()
    {
        sprintSpeed = speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementEnabled == true)
        {
            Move();
        }

        if (inSculptRange && !toggleScript.inGame)
        {
            prompt.ShowPrompt();
        }
        else { prompt.HidePrompt(); }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = sprintSpeed / 2;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && inSculptRange || Input.GetKeyDown(KeyCode.E) && toggleScript.inGame)
        {
            toggleScript.Toggle();
            if (MovementEnabled)
            {
                MovementEnabled = false;
                mr.enabled = false;
            } 
            else
            {
                MovementEnabled = true;
                mr.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            toggleScript.OpenInventory(toggleScript.currentPage + 1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            toggleScript.OpenInventory(toggleScript.currentPage - 1);
        }
    }

    private void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xInput, rb.velocity.y/speed, zInput) * speed;
    }

    public void DisableMove()
    {
        // Debug.Log("disable movement");
        rb.velocity = Vector3.zero;
        MovementEnabled = false;
    }

    public void EnableMove()
    {
        // Debug.Log("enable movement");
        MovementEnabled = true;
    }
}
