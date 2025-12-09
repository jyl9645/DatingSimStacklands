using UnityEngine;

public class Character: Card
{
    public GameObject gameManager;

    public float hearts = 4;

    //dialogues
    public DialogueNode mallDialogue;
    public DialogueNode coffeeDialogue;
    public DialogueNode arenaDialogue;
    public DialogueNode restaurantDialogue;

    void Update()
    {
        if (transform.childCount != 0 && !merging)
        {
            StartMerge();
        }
    }

    public void ChangeHearts(float change)
    {
        hearts += change;
        if (hearts <= 0)
        {
            // code late, end game
        }
    }

    private bool isDateCard(cardType cardtype)
    {
        if (cardtype != cardType.mallDate && cardtype != cardType.coffeeDate && cardtype != cardType.arenaDate && cardtype != cardType.restaurantDate)
        {
            return false;
        }
        return true;
    }

    public override void FinishMerge()
    {
        GameObject stacked = transform.GetChild(0).gameObject;
        cardType stackedType = stacked.GetComponent<Card>().type;

        if (isDateCard(stackedType))
        {
            switch (stackedType)
            {
                case cardType.mallDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(mallDialogue, gameObject);
                    break;
                case cardType.coffeeDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(coffeeDialogue, gameObject);
                    break;
                case cardType.arenaDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(arenaDialogue, gameObject);
                    break;
                case cardType.restaurantDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(restaurantDialogue, gameObject);
                    break;
            }
            stacked.transform.parent = null;
            merging = false;
            Destroy(stacked);

        }

        else
        {
            stacked.transform.parent = null;
            merging = false;
        }

    }
} 
