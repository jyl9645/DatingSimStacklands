using UnityEngine;

public class MoveCard : MonoBehaviour
{
    private Collider2D col;
    private Vector3 starDragPosition;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void onMouseDown()
    {
        starDragPosition = transform.position;
        transform.position = GetMousePositionInWorldSpace();
    }

    private void onMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void onMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        if (col.enabled != null && hitCollider.TryGetComponent(out ICardDropArea cardDropArea))
        {
            cardDropArea.onCardDrop(this);
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
}
