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
    public bool inSculptRange;
    private float sprintSpeed;
    [SerializeField] InteractPrompt prompt;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    private SpriteRenderer spriteRenderer;

    private bool facingFront = true;
    private bool facingRight = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        
        if (Input.GetKeyDown(KeyCode.E) && inSculptRange || 
           (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && toggleScript.inGame)
        {
            toggleScript.Toggle();
            if (MovementEnabled)
            {
                MovementEnabled = false;
                spriteRenderer.enabled = false;
            } 
            else
            {
                MovementEnabled = true;
                spriteRenderer.enabled = true;
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

        FlipPlayer(zInput, xInput);
        
    }

    private void FlipPlayer(float zInput, float xInput)
    {
        if (zInput > 0 && facingFront)
        {
            spriteRenderer.sprite = backSprite;
            facingFront = false;
        }
        if (zInput <= 0 && !facingFront)
        {
            spriteRenderer.sprite = frontSprite;
            facingFront = true;
        }
        
        if (xInput < 0 && facingRight || xInput >= 0 && !facingRight)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1,
                transform.localScale.y, transform.localScale.z);
            facingRight = !facingRight;
        }

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
