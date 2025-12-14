using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Character: Card
{
    public GameObject gameManager;

    public float hearts = 4;
    public GameObject heartContainer;
    public GameObject heartPrefab;

    //dialogues
    public DialogueNode mallDialogue;
    public DialogueNode coffeeDialogue;
    public DialogueNode arenaDialogue;
    public DialogueNode restaurantDialogue;

    //backgrounds
    public UnityEngine.UI.Image bkObject;
    public Sprite mallBK;
    public Sprite restaurantBK;
    public Sprite cafeBK;
    public Sprite stadiumBK;

    //juice
    public AudioScript audioScript;
    public Animator camAnimator;

    void Update()
    {
        if (transform.childCount != 0 && !merging)
        {
            cardType childType = transform.GetChild(0).gameObject.GetComponent<Card>().type;
            if (isDateCard(childType))
            {
                StartMerge();
            }
            else if ((childType == cardType.player && type == cardType.sabrina) || (childType == cardType.sabrina && type == cardType.player))
            {
                transform.DetachChildren();
                GameManagerSingle.Instance.GetComponent<EventScript>().player_sabrina_match();
            }
            else
            {
                if (type == cardType.sabrina)
                {
                    transform.DetachChildren();
                    GameManagerSingle.Instance.GetComponent<EventScript>().sabrina_no_match();
                }
                else if (type == cardType.player)
                {
                    transform.DetachChildren();
                    GameManagerSingle.Instance.GetComponent<EventScript>().player_no_match();
                }
            }
            
        }
    }

    public void ChangeHearts(float change)
    {
        if (change < 0)
        {
            for (int i = 0; i < Mathf.Abs(change); i++)
            {
                if (hearts <= 0) break;

                hearts --;
                Destroy(heartContainer.transform.GetChild(heartContainer.transform.childCount - 1 - i).gameObject);

                if (hearts <= 0)
                {
                    SceneManager.LoadScene("BadEnd");
                }
            }
        }

        else if (change > 0)
        {
            for (int i = 0; i < Mathf.Abs(change); i++)
            {
                if (hearts + 1 <= 10)
                {
                    hearts ++;
                    Instantiate(heartPrefab, parent: heartContainer.transform);
                }
            }
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
            foreach (ProgressBarScript bar in transform.GetComponentsInChildren<ProgressBarScript>())
            {
                Destroy(bar.gameObject);
            }
            stacked.transform.parent = null;
            merging = false;
            Destroy(stacked);

            switch (stackedType)
            {
                case cardType.mallDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(mallDialogue, gameObject);
                    bkObject.sprite = mallBK;
                    break;
                case cardType.coffeeDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(coffeeDialogue, gameObject);
                    bkObject.sprite = cafeBK;
                    break;
                case cardType.arenaDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(arenaDialogue, gameObject);
                    bkObject.sprite = stadiumBK;
                    break;
                case cardType.restaurantDate:
                    gameManager.GetComponent<DialogueManager>().InitiateDialogue(restaurantDialogue, gameObject);
                    bkObject.sprite = restaurantBK;
                    break;
                default:
                    break;
            }
        }

        else
        {            
            stacked.transform.parent = null;
            merging = false;
        }

    }
    
} 
