using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PrototypeDialogueManager : MonoBehaviour
{
    //public GameObject dialoguePanel;
    //public GameObject[] choicePanels;
    //public TMP_Text speakerText;
    //public Image image;
//
    //private TMP_Text dialogueText;
//
    //public DialogueNode current;
//
    //private bool isChoosing;
//
    //void Start()
    //{
    //    dialogueText = dialoguePanel.GetComponentInChildren<TMP_Text>();
//
    //    HideChoices();
    //    NextDialogue(current);
    //}
//
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && !isChoosing)
    //    {
    //        if (current.responses.Count == 1)
    //        {
    //            NextDialogue(current.responses[0]);
    //        }
    //        else if (current.responses.Count > 1)
    //        {
    //            ShowChoices();
    //        }
    //        else
    //        {
    //            dialogueText.text = "dialogue over";
    //        }
    //    }
    //}
//
    //private void NextDialogue(DialogueNode node)
    //{
    //    current = node;
//
    //    image.sprite = current.sprite;
    //    speakerText.text = current.speaker;
    //    dialogueText.text = current.dialogue;
    //    
    //}
//
    //public void NextIndexDialogue(int index)
    //{
    //    HideChoices();
    //    current = current.responses[index];
//
    //    image.sprite = current.sprite;
    //    speakerText.text = current.speaker;
    //    dialogueText.text = current.dialogue;
    //}
//
    //private void ShowChoices()
    //{
    //    for (var i = 0; i < current.responses.Count; i++)
    //    {
    //        choicePanels[i].SetActive(true);
    //        choicePanels[i].GetComponentInChildren<TMP_Text>().text = current.responses[i].dialogue;
    //    }
//
    //    isChoosing = true;
    //}
//
    //private void HideChoices()
    //{
    //    foreach (GameObject panel in choicePanels)
    //    {
    //        panel.GetComponentInChildren<TMP_Text>().text = "";
    //        panel.SetActive(false);
    //    }
//
    //    isChoosing = false;
    //}
//
}
