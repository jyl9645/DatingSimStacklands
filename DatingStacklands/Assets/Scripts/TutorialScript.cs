using TMPro;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    GameObject tutorialTextPanel;
    [SerializeField]
    TMP_Text tutorialText;

    //camera stats
    float defaultZoom = 5;
    Vector3 defaultPos = new Vector3(0,0,-10);

    public GameObject gameManager;

    //tutorial events
    public DialogueNode locationTutNode;
    public DialogueNode locationCamNode;
    public DialogueNode mergeTutNode;
    public DialogueNode giftTutNode;

   
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
