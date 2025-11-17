using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject[] choicePanels;

    public DialogueNode current;

    private bool isChoosing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideChoices();
        NextDialogue(current);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isChoosing)
        {
            if (current.responses.Count == 1)
            {
                NextDialogue(current.responses[0]);
            }
            else
            {
                ShowChoices();
            }
        }
    }

    private void NextDialogue(DialogueNode node)
    {
        current = node;
        dialoguePanel.GetComponentInChildren<TMP_Text>().text = current.dialogue;
        
    }

    public void NextIndexDialogue(int index)
    {
        HideChoices();
        current = current.responses[index];
        dialoguePanel.GetComponentInChildren<TMP_Text>().text = current.dialogue;
    }

    private void ShowChoices()
    {
        foreach (GameObject panel in choicePanels)
        {
            panel.SetActive(true);
        }

        for (var i = 0; i < current.responses.Count; i++)
        {
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

}
