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

    //tutorial vars
    public static DialogueNode tutorialCurrent;
    public static int currentTutLine;

    //cam animator
    public Animator camAnimator;

    //in game event nodes
    public DialogueNode mergeFail;
    public DialogueNode sabrinaNoMatch;
    public DialogueNode playerNoMatch;
    public DialogueNode sabrinaPlayerNoMatch;

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

        if (dialogueManager.current == getOffNode)
        {
            ResetTutorialBox(locationTutNode);
            
            //load only player and three cards
            //tutorial: cam zoom into the player first; then slowly zoom out until reaches full
        }

        else if (tutorialCurrent == locationCamNode)
        {
            //zoom onto the the location board then out
            
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

    public void draw_tutorial()
    {
        ResetTutorialBox(mergeTutNode);
        //zoom onto items then out
    }

    public void merge_tutorial()
    {
        ResetTutorialBox(giftTutNode);
        
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

/// <summary>
/// Resets the board's tutorial dialogue box to give hints/warnings
/// </summary>
/// <param name="startNode"></param>

    private void ResetTutorialBox(DialogueNode startNode)
    {
        tutorialCurrent = startNode;
        currentTutLine = 0;

        tutorialTextPanel.SetActive(true);
        tutorialText.text = tutorialCurrent.dialogue[currentTutLine];
    }
}
