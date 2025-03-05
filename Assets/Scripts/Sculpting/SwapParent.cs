using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapParent : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<Item>().inPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<Item>().inPlace = false;
        }
    }
}
