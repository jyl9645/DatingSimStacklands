using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    bool stackingBlocked = false;
    float stackingTimer = 0f;

    Transform draggingObject;
    public GameObject slot1;
    public float offset = -0.5f;
    void Update()
    {
        GetMouseClick();
        CheckForCollision();

        if (stackingBlocked)
        {
            stackingTimer -= Time.deltaTime;
            if (stackingTimer <= 0f){
                stackingBlocked = false;
            }
        }

    }

        public void GetMouseClick(){
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                Transform clicked = hit.collider.transform;

                if (clicked.parent != null)
                {
                    clicked.SetParent(null);
                    stackingBlocked = true;
                    stackingTimer = 0.5f;
                }

                // Only bring to front if NOT a parent
                if (clicked.childCount == 0)
                {
                    SpriteRenderer sr = clicked.GetComponent<SpriteRenderer>();
                    if (sr != null)
                    {
                        CardLayering.nextOrder++;
                        sr.sortingOrder = CardLayering.nextOrder;
                    }
                }

                draggingObject = clicked;
            }
        }

        if (Input.GetMouseButton(0) && draggingObject != null)
        {
            var v3 = Input.mousePosition;
            v3.z = 10;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3 = new Vector3(Mathf.Clamp(v3.x, -8, 8), Mathf.Clamp(v3.y, -4, 4), v3.z);
            draggingObject.position = v3;
        }
        if (Input.GetMouseButtonUp(0))
        {
            draggingObject = null;
        }
    }

    public static class CardLayering
    {
        public static int nextOrder = 0;
    }

    void CheckForCollision()
    {
        if (stackingBlocked) return;
        if (draggingObject == null) return;

        Collider2D col = draggingObject.GetComponent<Collider2D>();
        if (col == null) return;

        Collider2D[] hits = Physics2D.OverlapBoxAll(
            col.bounds.center,
            col.bounds.size,
            0f
        );

        foreach (Collider2D h in hits)
        {
            if (h.transform == draggingObject) continue;
            if (!h.CompareTag("Card")) continue;

            Transform newParent = h.transform;
            draggingObject.SetParent(newParent);

            Vector3 stackedPos = newParent.position;
            stackedPos.y += offset;

            draggingObject.position = stackedPos;

            return;
        }
    }

}
