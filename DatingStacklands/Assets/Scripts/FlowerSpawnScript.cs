using System;
using UnityEngine;

public class FlowerSpawnScript : MonoBehaviour
{
    public GameObject flowerCard;

    public GameObject sabrina;
    private Character sabrinaCharacter;

    private bool flowerMade;

    void Start()
    {
        sabrinaCharacter = sabrina.GetComponent<Character>();
    }

    void Update()
    {
        if (!DialogueManager.onDate && !flowerMade)
        {
            if (sabrinaCharacter.hearts >= 10)
            {
                GameObject flower = Instantiate(flowerCard);
                EventScript.InitCard(flower);
                StartCoroutine(LocationCard.LerpToTarget(flower, new Vector2(-2,0),0.5f));

                flowerMade = true;
            }
        }
    }
}
