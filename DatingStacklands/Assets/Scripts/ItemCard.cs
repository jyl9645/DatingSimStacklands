using System.Threading;
using NUnit.Framework.Interfaces;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemCard : Card
{
    cardType result;
    public GameObject[] datePossibilities; 
    public static bool tutMerged;

    void Update()
    {
        if (!transform.parent)
        {
            if (transform.childCount > 1 && merging == false)
            {
                Card[] allCards = GetComponentsInChildren<Card>();

                cardType possibleResult = JSONTool.CompareFormulas(allCards);

                if (possibleResult != cardType.none)
                {
                    result = possibleResult;
                    StartMerge();
                    merging = true;
                    return;
                }
                else
                {
                    foreach (Card card in transform.GetComponentsInChildren<Card>())
                    {
                        card.gameObject.transform.parent = null;
                    }
                    GameManagerSingle.Instance.GetComponent<EventScript>().merge_fail();
                }
            }
        }
    }

    public override void FinishMerge()
    {
        
        GameObject temp_tut_datecard = null;

        switch (result)
        {
            case cardType.mallDate:
                temp_tut_datecard = Instantiate(datePossibilities[0], gameObject.transform.position, Quaternion.identity);
                EventScript.InitCard(temp_tut_datecard);
                break;

            case cardType.coffeeDate:
                temp_tut_datecard = Instantiate(datePossibilities[1], gameObject.transform.position, Quaternion.identity);
                EventScript.InitCard(temp_tut_datecard);
                break;

            case cardType.arenaDate:
                temp_tut_datecard = Instantiate(datePossibilities[2], gameObject.transform.position, Quaternion.identity);
                EventScript.InitCard(temp_tut_datecard);
                break;

            case cardType.restaurantDate:
                temp_tut_datecard = Instantiate(datePossibilities[3], gameObject.transform.position, Quaternion.identity);
                EventScript.InitCard(temp_tut_datecard);
                break;
        }

        if (!tutMerged && temp_tut_datecard != null)
        {
            tutMerged = true;
            GameManagerSingle.Instance.GetComponent<EventScript>().merge_tutorial(temp_tut_datecard);
        }

        merging = false;

        Destroy(gameObject);
    }
}
