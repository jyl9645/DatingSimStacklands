using UnityEngine;

public class Character: MonoBehaviour
{
    public GameObject gameManager;

    public float heart = 4;
    private int mallCount = 0;
    private int coffeeCount = 0;
    private int arenaCount = 0;

    //dialogues
    public DialogueNode[] mallDialogues;
    public DialogueNode[] coffeeDialogues;
    public DialogueNode[] arenaDialogues;
    public DialogueNode restaurantDialogue;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHearts(float change)
    {
        heart += change;
        if (heart <= 0)
        {
            // code late, end game
        }
    }

    public void EnterDialogue()
    {
        if (transform.childCount != 0)
        {
            Card.cardType stackedType = transform.GetChild(0).gameObject.GetComponent<Card>().type;
            switch (stackedType)
            {
                case Card.cardType.mallDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(mallDialogues[mallCount]);
                    break;

                case Card.cardType.coffeeDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(coffeeDialogues[coffeeCount]);
                    break;

                case Card.cardType.arenaDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(arenaDialogues[arenaCount]);
                    break;

                case Card.cardType.restaurantDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(restaurantDialogue);
                    break;
            }
        }
    }
} 
