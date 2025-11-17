using UnityEngine;

public class CardDropArea : MonoBehaviour, ICardDropArea
{
    public void onCardDrop(MoveCard card)
    {
        card.transform.position = transform.position;
        Debug.Log("Card");
    }
}
