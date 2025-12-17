using Unity.VisualScripting;
using UnityEngine;

public class CameraAnimScript : MonoBehaviour
{
    public Animator camAnim;
    public DialogueManager dM;

    //heart container
    public GameObject heartContainer;

    public void Transition()
    {
        if (dM.dateScreen.activeSelf)
        {
            if (dM.current == GameManagerSingle.Instance.GetComponent<EventScript>().getOffNode)
            {
                GameManagerSingle.Instance.GetComponent<EventScript>().get_off_Tutorial();
            }
            dM.CloseDialogue();
        }
        else
        {
            GameManagerSingle.Instance.GetComponent<EventScript>().unhighlight();
            dM.dateScreen.SetActive(true);
            dM.HideCards();

            RectTransform containerTransform = heartContainer.GetComponent<RectTransform>();
            Vector3 tempheartContPos = containerTransform.anchoredPosition;
            tempheartContPos.x = -5;

            containerTransform.anchoredPosition = tempheartContPos;
            containerTransform.localScale = new Vector3(1,1,1);
        }
        
    }
}
