using Unity.VisualScripting;
using UnityEngine;

public class DragManager : MonoBehaviour
{

    //the currently dragged card
    GameObject currentDrag;

    //spacing in between stacked cards
    private float offset = -0.5f;
    //sorting order for cards that are currently dragging/selected
    private int upOrder = 5;
    public AudioScript audioScript;
    void Start()
    {
      audioScript = GameManagerSingle.Instance.GetComponent<AudioScript>();
      }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                audioScript.cardpickSoundPlay();
                currentDrag = hit.collider.gameObject;
                currentDrag.GetComponent<Animator>().SetTrigger("Scaledup");

                if (currentDrag.GetComponent<Card>().frozen)
                {
                    currentDrag = null;
                    return;
                }
                
                if (currentDrag.transform.parent)
                {
                    foreach (Card cardChild in currentDrag.GetComponentsInChildren<Card>())
                    {
                        cardChild.gameObject.transform.parent = null;
                    }
                    GetSpriteRenderer(currentDrag).sortingOrder = 0;
                }
                
                if (currentDrag.transform.childCount != 0)
                {
                    foreach (Transform child in transform)
                    {
                        GetSpriteRenderer(child.gameObject).sortingOrder += upOrder;
                    }
                }
                else
                {
                    GetSpriteRenderer(currentDrag).sortingOrder = upOrder;
                }
            }
        }

        else if (currentDrag && Input.GetMouseButton(0))
        {
            Vector3 v3 = Input.mousePosition;
            v3.z = 10;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3 = new Vector3(Mathf.Clamp(v3.x, -8, 8), Mathf.Clamp(v3.y, -4, 4), v3.z);
            currentDrag.transform.position = v3;
            GetSpriteRenderer(currentDrag).sortingOrder = upOrder;
        }

        else if (currentDrag && Input.GetMouseButtonUp(0))
        {
            currentDrag.transform.position = new Vector3(currentDrag.transform.position.x, currentDrag.transform.position.y, 0);
            currentDrag.GetComponent<Animator>().SetTrigger("Scaleddown");
            audioScript.cardDropSoundPlay();
            
            if (currentDrag.transform.childCount > 1)
            {
                foreach (Transform child in transform)
                {
                    GetSpriteRenderer(child.gameObject).sortingOrder -= upOrder;
                }
            }
            else
            {
                GetSpriteRenderer(currentDrag).sortingOrder = 0;
            }

            CheckForCollision();
            currentDrag = null;
        }
    }

    private void CheckForCollision()
    {
        Collider2D col = currentDrag.GetComponent<Collider2D>();
        if (col == null) return;

        Collider2D[] hits = Physics2D.OverlapBoxAll(
            col.bounds.center,
            col.bounds.size/2,
            0f
        );
        audioScript.stackSoundPlay();

        foreach (Collider2D h in hits)
        {
            if (h.gameObject == currentDrag) continue;
            if (!h.CompareTag("Card")) continue;

            Transform newParent = h.transform;
            currentDrag.transform.SetParent(newParent);

            if (currentDrag.transform.parent)
            {
                int parentOrder = GetSpriteRenderer(currentDrag.transform.parent.gameObject).sortingOrder;
                GetSpriteRenderer(currentDrag).sortingOrder = parentOrder + 1;
            }
            
            Vector3 stackedPos = newParent.position;
            stackedPos.y += offset;
            currentDrag.transform.position = stackedPos;
            return;
        }

    }

    private SpriteRenderer GetSpriteRenderer(GameObject card)
    {
       return card.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
}
