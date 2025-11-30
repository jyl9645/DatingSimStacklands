using NUnit.Framework.Interfaces;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemCard : Card
{
    cardType result;
    public GameObject[] datePossibilities; 

    void Update()
    {
        if (!transform.parent)
        {
            if (transform.childCount != 0 && merging == false)
            {
                Card[] childrenCards = GetComponentsInChildren<Card>();
                cardType possibleResult = JSONTool.CompareFormulas(childrenCards);

                if (possibleResult != cardType.none)
                {
                    print("merging");
                    result = possibleResult;
                    StartMerge();
                    merging = true;
                }
            }
        }
    }

    public override void FinishMerge()
    {
        print(result);
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
