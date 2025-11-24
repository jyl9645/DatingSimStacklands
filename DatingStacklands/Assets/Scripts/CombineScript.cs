using UnityEngine;

public class CombineScript : MonoBehaviour
{
    private float timer = 1f;
    public GameObject gameManager;

    public DialogueNode a;
    public GameObject dateCard;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount != 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                GameObject card = transform.GetChild(0).gameObject;
                if (card == dateCard)
                {
                    if (!gameManager.GetComponent<DialogueManager>().onDate)
                    {
                        gameManager.GetComponent<DialogueManager>().InitiateDialogue(a);
                        Destroy(card);
                    }
                       
                }
            }
        }
    }
}
