using System.Threading;
using NUnit.Framework.Interfaces;
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
            if (transform.childCount != 0 && merging == false)
            {
                Card[] allCards = GetComponentsInChildren<Card>();

                foreach (Card card in allCards)
                {
                    print(card);
                }

                cardType possibleResult = JSONTool.CompareFormulas(allCards);

                if (possibleResult != cardType.none)
                {
                    result = possibleResult;
                    StartMerge();
                    merging = true;
                }
            }
        }
    }

    public override void FinishMerge()
    {
        if (!tutMerged)
        {
            tutMerged = true;
            EventScript.merged = true;
        }
        switch (result)
        {
            case cardType.mallDate:
                Instantiate(datePossibilities[0], gameObject.transform.position, Quaternion.identity);
                break;

            case cardType.coffeeDate:
                Instantiate(datePossibilities[1], gameObject.transform.position, Quaternion.identity);
                break;

            case cardType.arenaDate:
                Instantiate(datePossibilities[2], gameObject.transform.position, Quaternion.identity);
                break;

            case cardType.restaurantDate:
                Instantiate(datePossibilities[3], gameObject.transform.position, Quaternion.identity);
                break;
        }

        merging = false;

        Destroy(gameObject);
    }
}
