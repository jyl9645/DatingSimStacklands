using UnityEngine;

public class CombineScript : MonoBehaviour
{
    private float timerDefault = 1f;
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
                if (card.GetComponent<Card>().type == Card.cardType.mallDate)
                {
                    if (!gameManager.GetComponent<DialogueManager>().onDate)
                    {
                        timer = timerDefault;
                        gameManager.GetComponent<DialogueManager>().InitiateDialogue(a);
                        Destroy(card);
                    }
                       
                }
            }
        }
    }
}
