using UnityEngine;

public class LocationCard : Card
{
    public GameObject player;
    public GameObject gameManager;

    public GameObject[] itemPool;

    void Update()
    {
        if (transform.childCount != 0 && !merging)
        {
            if (transform.GetChild(0).GetComponent<Card>().type == cardType.player)
            {
                player = transform.GetChild(0).gameObject;
                StartMerge();
            }
        }
    }

    public override void FinishMerge()
    {
        int numItems = Random.Range(1,3);
        for (var i = 0; i < numItems + 1; i ++)
        {
            int randomChoice = UnityEngine.Random.Range(0, itemPool.Length);
            GameObject newItem = Instantiate(itemPool[randomChoice]);

            float randomX = Random.Range(gameObject.transform.position.x - 1f, gameObject.transform.position.x + 1f);
            float randomY = Random.Range(gameObject.transform.position.y - 1f, gameObject.transform.position.y + 1f);

            newItem.transform.position = new Vector2(randomX, randomY);
        }

        player.transform.parent = null;
        merging = false;
        
        gameManager.GetComponent<DayManager>().RemoveAction();
    }

}
