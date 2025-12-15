using UnityEngine;

public class CameraAnimScript : MonoBehaviour
{
    public Animator camAnim;
    public DialogueManager dM;

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
            dM.dateScreen.SetActive(true);
            dM.HideCards();
        }
        
    }
}
