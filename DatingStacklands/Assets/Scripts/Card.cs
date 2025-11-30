using System;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public cardType type;

    public GameObject progressPrefab;

    public bool merging;

    [System.Serializable]
    public enum cardType
    {
        //date cards
        mallDate,
        coffeeDate,
        arenaDate,
        restaurantDate,

        //item cards
        vinylItem,
        clothesItem,
        pretzelsItem,
        espressoItem,
        cakeItem,
        magazineItem,
        ticketItem,
        flowersItem,

        //characters
        sabrinaCharacter,
        coltonCharacter,
        playerCharacter,

        //locations
        mallLocation,
        coffeeLocation,
        arenaLocation,
        restaurantLocation,

        none
    }
    protected void StartMerge()
    {
        Instantiate(progressPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2), Quaternion.identity, parent:gameObject.transform);
    }

    public virtual void FinishMerge()
    {
        
    }

}
