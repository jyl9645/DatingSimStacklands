using UnityEngine;

public class ItemCard : Card
{
    void Update()
    {
        if (!transform.parent)
        {
            if (transform.childCount != 0)
            {
                Card[] childrenCards = GetComponentsInChildren<Card>();
                cardType possibleResult = JSONTool.CompareFormulas(childrenCards);

                if (possibleResult != cardType.none)
                {
                    StartMerge(possibleResult);
                }
            }
        }
    }

    void StartMerge(cardType result)
    {
        Instantiate(progressPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 10), Quaternion.identity);
    }

    void FinishMerge()
    {
        
    }
}
