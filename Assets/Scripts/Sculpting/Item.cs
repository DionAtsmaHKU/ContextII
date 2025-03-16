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
    private float rotateSpeed = -50f;
    private bool flipped = false;

    private void OnEnable()
    {
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (!dragging || !toggle.inGame) { return; }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FlipVertical();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            FlipHorizontal();
        }

        Vector2 mousePos = GetMousePos();
        transform.position = mousePos;
        transform.position = mousePos - offset;
        Debug.Log(mousePos);
        CheckBounds();
    }

    private void FlipHorizontal()
    {
        flipped = !flipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        if (!flipped) { transform.Rotate(new Vector3(0, 0, 90)); }
        else { transform.Rotate(new Vector3(0, 0, -90)); }
    }

    private void FlipVertical()
    {
        flipped = !flipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        if (flipped) { transform.Rotate(new Vector3(0, 0, 90)); }
        else { transform.Rotate(new Vector3(0, 0, -90)); }
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
