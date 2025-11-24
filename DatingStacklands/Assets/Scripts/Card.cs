using UnityEngine;

public class Card : MonoBehaviour
{
    public cardType type;

    public enum cardType
    {
        mallDate,
        coffeeDate,
        arenaDate,
        restaurantDate
    }
}
