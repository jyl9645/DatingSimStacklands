using UnityEngine;

public class Card : MonoBehaviour
{
    public cardType type;

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
        restaurantLocation

    }
}
