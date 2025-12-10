using NUnit.Framework.Constraints;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
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
    public static DialogueNode tutorialCurrent;
    public static int currentTutLine;

    //cam animator
    public Animator camAnimator;

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
            camAnimator.SetTrigger("Transit");
            
            ResetTutorialBox(locationTutNode);

        }

        else if (drawn)
        {
            ResetTutorialBox(mergeTutNode);

            drawn = false;
        }

        else if (merged)
        {
            ResetTutorialBox(giftTutNode);

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

    private void ResetTutorialBox(DialogueNode startNode)
    {
        tutorialCurrent = startNode;
        currentTutLine = 0;

        tutorialTextPanel.SetActive(true);
        tutorialText.text = tutorialCurrent.dialogue[currentTutLine];
    }
}
