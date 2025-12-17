using System.Linq;
using NUnit.Framework.Constraints;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{
    [SerializeField]
    public GameObject tutorialTextPanel;
    [SerializeField]
    TMP_Text tutorialText;
    [SerializeField]
    GameObject dateScreen;

    //camera stats
    float defaultZoom = 5;
    Vector3 defaultPos = new Vector3(0,0,-10);

    private DialogueManager dialogueManager;

    //tutorial events
    public DialogueNode getOffNode;
    public DialogueNode locationTutNode;
    public DialogueNode locationCamNode;
    public DialogueNode mergeTutNode;
    public DialogueNode giftTutNode;

    //end events
    public DialogueNode badend;
    public DialogueNode rejectend;
    public DialogueNode goodend;

    //tutorial vars
    public static DialogueNode tutorialCurrent;
    public static int currentTutLine;

    //tutorial cards
    public GameObject player;
    public GameObject mallCard;
    public GameObject cafeCard;
    public GameObject arenaCard;
    public GameObject sabrinaCard;

    //cam animator
    public Animator camAnimator;

    public AudioScript audioScript;

    //in game event nodes
    public DialogueNode mergeFail;
    public DialogueNode sabrinaNoMatch;
    public DialogueNode playerNoMatch;
    public DialogueNode sabrinaPlayerNoMatch;

    //darken screen
    public GameObject darkenScreen;

    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        audioScript = GetComponent<AudioScript>();
    }

    void Update()
    {
        //all tutorial stuff
        if (Input.GetMouseButtonUp(0) && tutorialTextPanel.activeSelf)
        {
            currentTutLine ++;

            if (currentTutLine >= tutorialCurrent.dialogue.Length)
            {
                if (tutorialCurrent.responses.Count != 0)
                {
                    ResetTutorialBox(tutorialCurrent.responses[0]);
                }
                else
                {
                    tutorialCurrent = null;
                    currentTutLine = 0;
                    tutorialTextPanel.SetActive(false);
                }
            }
            else
            {
                tutorialText.text = tutorialCurrent.dialogue[currentTutLine];
            }
        }

        else if (tutorialCurrent == locationCamNode && !mallCard.activeSelf && !arenaCard.activeSelf && !cafeCard.activeSelf)
        {
            location_Cam_tutorial();
        }

        //ending stuff
        else if (dialogueManager.current == badend)
        {
            SceneManager.LoadScene("BadEnd");
        }
        else if (dialogueManager.current == rejectend)
        {
            SceneManager.LoadScene("RejectEnd");
        }
        else if (dialogueManager.current == goodend)
        {
            SceneManager.LoadScene("GoodEnd");
        }
    }

//event functions

    public void get_off_Tutorial()
    {
        print("get tut");

        unhighlight();

        InitCard(player);
        ResetTutorialBox(locationTutNode);
        GameObject[] toHighlight = {player};
        highlight(toHighlight);
    }

    public void location_Cam_tutorial()
    {
        print("location tut");
        unhighlight();

        InitCard(mallCard);
        InitCard(arenaCard);
        InitCard(cafeCard);
        GameObject[] toHighlight = {mallCard, arenaCard, cafeCard, player};
        highlight(toHighlight);
    }

    public void draw_tutorial()
    {
        print("draw tut");
        unhighlight();

        ResetTutorialBox(mergeTutNode);
        ItemCard[] itemCards = FindObjectsByType<ItemCard>(FindObjectsSortMode.None);
        GameObject[] itemObjects = itemCards.Select(comp => comp.gameObject).ToArray();

        highlight(itemObjects);
    }

    public void merge_tutorial(GameObject datecard)
    {
        print("merge tut");
        unhighlight();

        InitCard(sabrinaCard);
        ResetTutorialBox(giftTutNode);

        GameObject[] datecardHighlight = {datecard, sabrinaCard};
        highlight(datecardHighlight);
        
    }

    public void merge_fail()
    {
        if (tutorialCurrent != mergeFail)
        {
            ResetTutorialBox(mergeFail);
        }
        
    }

    public void player_no_match()
    {
        if (tutorialCurrent != playerNoMatch)
        {
            ResetTutorialBox(playerNoMatch);
        }
        
    }

    public void player_sabrina_match()
    {
        if (tutorialCurrent != sabrinaPlayerNoMatch)
        {
            ResetTutorialBox(sabrinaPlayerNoMatch);
        }
        
    }

    public void sabrina_no_match()
    {
        if (tutorialCurrent != sabrinaNoMatch)
        {
            ResetTutorialBox(sabrinaNoMatch);
        }
        
    }

    private void ResetTutorialBox(DialogueNode startNode)
    {
        tutorialCurrent = startNode;
        currentTutLine = 0;

        tutorialTextPanel.SetActive(true);
        tutorialText.text = tutorialCurrent.dialogue[currentTutLine];
    }

    private void highlight(GameObject[] highlightedCards)
    {
        darkenScreen.SetActive(true);
        darkenScreen.GetComponent<Animator>().SetBool("Darken", true);

        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cards)
        {
            if (!highlightedCards.Contains(card))
            {
                card.GetComponent<Animator>().SetBool("Darken", true);
            }
        }
    }

    public void unhighlight()
    {
        darkenScreen.GetComponent<Animator>().SetBool("Darken", false);
        darkenScreen.SetActive(false);

        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject card in cards)
        {
            card.GetComponent<Animator>().SetBool("Darken", false);
        }
    }

    public static void InitCard(GameObject card)
    {
        card.SetActive(true);
        Animator cardAnim = card.GetComponent<Animator>();

        cardAnim.SetTrigger("Init");
        cardAnim.SetTrigger("Enter");
    }
}
