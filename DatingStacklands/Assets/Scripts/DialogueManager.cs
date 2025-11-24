using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dateScreen;

    public GameObject dialoguePanel;
    public GameObject[] choicePanels;
    public TMP_Text speakerText;
    public Image image;

    private TMP_Text dialogueText;

    public DialogueNode current;

    public bool onDate;
    private bool isChoosing;

    private GameObject[] cards;

    void Start()
    {
        dialogueText = dialoguePanel.GetComponentInChildren<TMP_Text>();

        CloseDialogue();
    }

    void Update()
    {
        if (onDate)
        {
            if (Input.GetMouseButtonDown(0) && !isChoosing)
            {
                if (current.responses.Count == 1)
                {
                    NextDialogue(current.responses[0]);
                }
                else if (current.responses.Count > 1)
                {
                    ShowChoices();
                }
                else
                {
                    CloseDialogue();
                }
            }
        }
    }

    public void InitiateDialogue(DialogueNode root)
    {
        onDate = true;
        current = root;
        dateScreen.SetActive(true);
        NextDialogue(current);

        cards = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject card in cards)
        {
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

    private void NextDialogue(DialogueNode node)
    {
        current = node;

        image.sprite = current.sprite;
        speakerText.text = current.speaker;
        dialogueText.text = current.dialogue;
    }

    public void NextIndexDialogue(int index)
    {
        HideChoices();
        current = current.responses[index];

        image.sprite = current.sprite;
        speakerText.text = current.speaker;
        dialogueText.text = current.dialogue;
    }

    private void ShowChoices()
    {
        for (var i = 0; i < current.responses.Count; i++)
        {
            choicePanels[i].SetActive(true);
            choicePanels[i].GetComponentInChildren<TMP_Text>().text = current.responses[i].dialogue;
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

}
