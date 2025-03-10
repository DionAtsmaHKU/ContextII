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

    // Update is called once per frame
    void Update()
    {
        if (MovementEnabled == true)
        {
            Move();
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            toggleScript.Toggle();
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
