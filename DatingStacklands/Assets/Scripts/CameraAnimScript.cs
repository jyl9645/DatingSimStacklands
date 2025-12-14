using UnityEngine;

public class CameraAnimScript : MonoBehaviour
{
    public Animator camAnim;
    public DialogueManager dM;

    public void Transition()
    {
        if (dM.dateScreen.activeSelf)
        {
            dM.CloseDialogue();
        }
        else
        {
            dM.dateScreen.SetActive(true);
            dM.HideCards();
        }
        
    }
}
