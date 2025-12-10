using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{

    public TMP_Text dayText;
    public TMP_Text actionsText;

    public int day = 1;
    private int actionsDefault = 2;
    public int actions = 2;

    void Start()
    {
        actions = actionsDefault;
        day = 1;

        dayText.text = "Day " + day;
        actionsText.text = "Actions: " + actions;
    }

    /// <summary>
    ///  Removes one action from the day. If day is on its last action, it moves to next day. 
    ///  Call this after the activity is finished.
    /// </summary>
    public void RemoveAction()
    {
        if (actions > 1)
        {
            actions --;
            Debug.Log(actions);
            actionsText.text = "Actions: " + actions;
        }
        else
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        if (day < 4)
        {
            day ++;
            dayText.text = "Day " + day;

            actions = actionsDefault;
            actionsText.text = "Actions: " + actions;
        }
        else
        {
            //show gameover screen
        }
    }
}
