using UnityEngine;

public class CameraAnimScript : MonoBehaviour
{
    public Animator camAnim;
    public DialogueManager dM;

    public void Transition()
    {
        dM.CloseDialogue();
    }
}
