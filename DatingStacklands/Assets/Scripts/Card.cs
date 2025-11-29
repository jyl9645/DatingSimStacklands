using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    public cardType type;

    public GameObject progressPrefab;

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

}
