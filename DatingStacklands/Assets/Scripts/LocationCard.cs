using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCard : Card
{
    public GameObject player;

    public GameObject[] itemPool;

    public static bool tutDrawn;

    public GameObject[] tutorialItems;

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
        if (!tutDrawn)
        {
            float interval = -4;
            tutDrawn = true;
            GameManagerSingle.Instance.GetComponent<EventScript>().draw_tutorial();
            foreach (GameObject itemObj in tutorialItems)
            {
                GameObject item = Instantiate(itemObj);
                EventScript.InitCard(item);
                StartCoroutine(LerpToTarget(item, new Vector2(interval,0),0.5f));
                interval += 2;
            }
        }
        else
        {
            float interval = -4;
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
                EventScript.InitCard(newItem);
                tempItems[randomChoice] = null;

                StartCoroutine(LerpToTarget(newItem, new Vector2(interval, 0),0.5f));
                interval += 2;
            }
        }

        player.transform.parent = null;
        StartCoroutine(LerpToTarget(player, new Vector2(-2,2.4f), 0.5f));
        merging = false;
        
        GameManagerSingle.Instance.GetComponent<DayManager>().RemoveAction();
    }

    public static IEnumerator LerpToTarget(GameObject obj, Vector2 endPos, float dur)
    {
        float timePassed = 0;
        Vector2 startPos = obj.transform.position;

        while (timePassed < dur)
        {
            timePassed += Time.deltaTime;
            float t = timePassed / dur;

            obj.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        obj.transform.position = endPos;
    }

}
