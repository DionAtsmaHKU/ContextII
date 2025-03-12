using UnityEngine;

public class Item : MonoBehaviour
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

    private void OnEnable()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (!dragging || !toggle.inGame) { return; }

        Vector2 mousePos = GetMousePos();
        transform.position = mousePos;
        transform.position = mousePos - offset;
        Debug.Log(mousePos);
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
            4.14f);
    }
}
