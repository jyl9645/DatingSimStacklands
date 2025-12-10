using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventScript : MonoBehaviour
{
    [SerializeField]
    GameObject tutorialTextPanel;
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

    //tutorial bools
    public static bool drawn;
    public static bool merged;

    //tutorial vars
    DialogueNode tutorialCurrent;
    int currentTutLine;

    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    void Update()
    {
        //all tutorial stuff
        if (Input.GetMouseButtonDown(0) && tutorialTextPanel.activeSelf)
        {
            currentTutLine ++;

            if (currentTutLine >= tutorialCurrent.dialogue.Length)
            {
                tutorialCurrent = null;
                currentTutLine = 0;
                tutorialTextPanel.SetActive(false);
            }
            else
            {
                tutorialText.text = tutorialCurrent.dialogue[currentTutLine];
            }
        }

        if (dialogueManager.current == getOffNode)
        {
            dialogueManager.CloseDialogue();
            
            tutorialCurrent = locationTutNode;
            currentTutLine = 0;

            tutorialTextPanel.SetActive(true);
            tutorialText.text = tutorialCurrent.dialogue[currentTutLine];

        }

        else if (drawn)
        {
            tutorialCurrent = mergeTutNode;
            currentTutLine = 0;

            tutorialTextPanel.SetActive(true);
            tutorialText.text = tutorialCurrent.dialogue[currentTutLine];

            drawn = false;
        }

        else if (merged)
        {
            tutorialCurrent = giftTutNode;
            currentTutLine = 0;

            tutorialTextPanel.SetActive(true);
            tutorialText.text = tutorialCurrent.dialogue[currentTutLine];

            merged = false;
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
}
