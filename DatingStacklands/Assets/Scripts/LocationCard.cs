using System.Collections.Generic;
using UnityEngine;

public class LocationCard : Card
{
    public GameObject player;

    public GameObject[] itemPool;

    public static bool tutDrawn;

    void Update()
    {
        if (transform.childCount > 1 && !merging)
        {
            if (transform.GetChild(1).GetComponent<Card>().type == cardType.player)
            {
                player = transform.GetChild(1).gameObject;
                StartMerge();
            }
        }
    }

    public override void FinishMerge()
    {
        int numItems = Random.Range(2,3);
        GameObject[] tempItems = (GameObject[])itemPool.Clone();

        for (var i = 0; i < numItems; i ++)
        {
            int randomChoice = Random.Range(0, tempItems.Length);
            while (tempItems[randomChoice] == null)
            {
                randomChoice = Random.Range(0, tempItems.Length);
            }

            GameObject newItem = Instantiate(tempItems[randomChoice]);
            tempItems[randomChoice] = null;

            float randomX = Random.Range(gameObject.transform.position.x - 1f, gameObject.transform.position.x + 1f);
            float randomY = Random.Range(gameObject.transform.position.y - 1f, gameObject.transform.position.y + 1f);

            newItem.transform.position = new Vector2(randomX, randomY);
        }

        player.transform.parent = null;
        merging = false;
        if (!tutDrawn)
        {
            tutDrawn = true;
            GameManagerSingle.Instance.GetComponent<EventScript>().draw_tutorial();
        }
        
        GameManagerSingle.Instance.GetComponent<DayManager>().RemoveAction();
    }

}
