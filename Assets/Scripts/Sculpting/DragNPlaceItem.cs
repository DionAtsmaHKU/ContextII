using UnityEngine;

public class DragNPlaceItem : MonoBehaviour
{
    public ImpactScore impactScore;

    [Header("Bounds")]
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;

    [Header("Other")]
    [SerializeField] Camera cam;
    public ToggleMinigame toggle;
    public bool dragging = false;
    private Vector2 offset = Vector2.zero;
    public bool inPlace = false;

    // Update is called once per frame
    void Update()
    {
        if (!dragging || !toggle.inGame) { return; }

        Vector2 mousePos = GetMousePos();
        transform.position = mousePos;
        transform.position = mousePos - offset;
        CheckBounds();
    }

    private void OnMouseDown()
    {
        dragging = true;
        offset = GetMousePos() - new Vector2(transform.position.x, transform.position.y);
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private Vector2 GetMousePos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void CheckBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax),
            0);
    }
}
