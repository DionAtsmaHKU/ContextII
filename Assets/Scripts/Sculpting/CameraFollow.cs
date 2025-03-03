using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
