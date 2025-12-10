using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;

public class DialogueManager : MonoBehaviour
{
    //Parent for date dialogue UI
    public GameObject dateScreen;

    //Gameobjects of date dialogue
    public GameObject dialoguePanel;
    public GameObject[] choicePanels;
    
    public Image dialogueBox;
    public Image background;

    public Image image;
    public TMP_Text heartCounter;

    //text of dialogue box
    private TMP_Text dialogueText;

    //current node
    public DialogueNode current;
    //current line of node
    public int currentLine;
    //current character
    public GameObject dater;

    //bools to check date status
    public static bool onDate;
    private bool isChoosing;

    //array of saved cards to show after dialogue
    private GameObject[] cards;

    //dialogue box prefabs
    public Sprite sabrinaBox;
    public Sprite playerBox;
    public Sprite noBox;

    public Sprite defaultSprite;

    //tutorial/start stuff
    public DialogueNode startDialogue;
    public GameObject sabrinaObject;
    public Sprite busBK;

    //animator
    public Animator camAnim;

    void Start()
    {
        dialogueText = dialoguePanel.GetComponentInChildren<TMP_Text>();

        HideChoices();

        InitiateDialogue(startDialogue, sabrinaObject);
        background.sprite = busBK;
        
    }

    void Update()
    {
        if (onDate && Input.GetMouseButtonDown(0) && !isChoosing)
        {
            //if there is more dialogue lines to go in the node
            if (currentLine + 1 < current.dialogue.Length)
            {
                NextLine();
            }
            else
            {
                if (current.responses.Count == 1)
                {
                    NextDialogueNode(0);
                }
                else if (current.responses.Count > 1)
                {
                    ShowChoices();
                }
                else
                {
                    camAnim.SetTrigger("Transit");
                }
            }
        }
    }

    public void InitiateDialogue(DialogueNode root, GameObject datee)
    {
        dater = datee;
        onDate = true;
        current = root;
        dateScreen.SetActive(true);
        currentLine = 0;

        if (current.conditionOperator == DialogueNode.op.lessthan)
        {
            if (dater.GetComponent<Character>().hearts >= current.condition)
            {
                current = current.responses[0];
            }
        }
        if (current.conditionOperator == DialogueNode.op.morethan)
        {
            if (dater.GetComponent<Character>().hearts < current.condition)
            {
                current = current.responses[0];
            }
            
        }

        dialogueText.text = current.dialogue[currentLine];
        ChangeDialogueBox(current.speaker);
        ChangeCharImage(current.sprite[currentLine]);
        heartCounter.text = dater.GetComponent<Character>().hearts.ToString();

        cards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject card in cards)
        {
            print(card);
            card.SetActive(false);
        }
    }

    public void CloseDialogue()
    {
       onDate = false;
       current = null;
       dateScreen.SetActive(false);
       HideChoices();
       GetComponent<DayManager>().RemoveAction();

       foreach (GameObject card in cards)
       {
           if (card)
           {
               card.SetActive(true);
           }
       }
    }

    private void NextDialogueNode(int index)
    {
        current = current.responses[index];

        if (current.conditionOperator == DialogueNode.op.lessthan)
        {
            if (dater.GetComponent<Character>().hearts >= current.condition)
            {
                NextDialogueNode(0);
            }
        }
        else if (current.conditionOperator == DialogueNode.op.morethan)
        {
            if (dater.GetComponent<Character>().hearts < current.condition)
            {
                NextDialogueNode(0);
            }
            
        }

        currentLine = 0;
        
        dialogueText.text = current.dialogue[currentLine];
        ChangeDialogueBox(current.speaker);
        ChangeCharImage(current.sprite[currentLine]);

        dater.GetComponent<Character>().ChangeHearts(current.heart_change);
        heartCounter.text = dater.GetComponent<Character>().hearts.ToString();
    }

    private void NextLine()
    {
        currentLine ++;

        dialogueText.text = current.dialogue[currentLine];
        ChangeDialogueBox(current.speaker);
        ChangeCharImage(current.sprite[currentLine]);
    }

    public void NextIndexDialogueNode(int index)
    {
        HideChoices();
        
        NextDialogueNode(index);
    }

    private void ShowChoices()
    {
        for (var i = 0; i < current.responses.Count; i++)
        {
            choicePanels[i].SetActive(true);
            choicePanels[i].GetComponentInChildren<TMP_Text>().text = current.responses[i].dialogue[0];
        }

        isChoosing = true;
    }

    private void HideChoices()
    {
        foreach (GameObject panel in choicePanels)
        {
            panel.GetComponentInChildren<TMP_Text>().text = "";
            panel.SetActive(false);
        }

        isChoosing = false;
    }

    private void HideCards()
    {
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card"))
        {
            card.SetActive(false);
        }
    }

    private void ChangeDialogueBox(String name)
    {
        if (name == "Sabrina")
        {
            dialogueBox.sprite = sabrinaBox;
        }
        else if (name == "You")
        {
            dialogueBox.sprite = playerBox;
        }
        else
        {
            dialogueBox.sprite = noBox;
        }
    }

    private void ChangeCharImage(Sprite sprite)
    {
        if (sprite == null)
        {
            image.sprite = defaultSprite;
        }
        else
        {
            image.sprite = sprite;
        }
    }
}
