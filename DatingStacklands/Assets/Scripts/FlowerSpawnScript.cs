using System;
using UnityEngine;

public class FlowerSpawnScript : MonoBehaviour
{
    public GameObject flowerCard;

    public GameObject sabrina;
    public GameObject colton;

    private Character sabrinaCharacter;
    private Character coltonCharacter;

    private bool flowerMade;

    void Start()
    {
        sabrinaCharacter = sabrina.GetComponent<Character>();
        coltonCharacter = colton.GetComponent<Character>();
    }

    void Update()
    {
        if (!DialogueManager.onDate && !flowerMade)
        {
            if (sabrinaCharacter.hearts >= 10 || coltonCharacter.hearts >= 10)
            {
                Instantiate(flowerCard);
                flowerMade = true;
            }
        }
    }
}
