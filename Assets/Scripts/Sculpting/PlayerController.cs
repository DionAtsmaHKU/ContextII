using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ToggleMinigame toggleScript;
    [SerializeField] bool MovementEnabled = true;
    public bool inSculptRange;
    private float sprintSpeed;

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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = sprintSpeed / 2;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && inSculptRange)
        {
            toggleScript.Toggle();
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
        Debug.Log("disable movement");
        MovementEnabled = false;
    }

    public void EnableMove()
    {
        Debug.Log("enable movement");
        MovementEnabled = true;
    }
}
