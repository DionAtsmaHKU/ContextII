using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class DragNPlaceItem : MonoBehaviour
{
    public ImpactScore impactScore;

    [SerializeField] Camera cam;
    [SerializeField] ToggleMinigame toggle;
    private bool dragging = false;
    private Vector2 offset = Vector2.zero;
    public bool inPlace = false;

    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    // Update is called once per frame
    void Update()
    {
        if (!dragging || !toggle.inGame) { return; }

        Vector2 mousePos = GetMousePos();
        transform.position = mousePos - offset;
        CheckBounds();
    }

    private void OnMouseDown()
    {
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private Vector2 GetMousePos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseOver()
    {
        
    }

    private void CheckBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax),
            0);
    }
}
