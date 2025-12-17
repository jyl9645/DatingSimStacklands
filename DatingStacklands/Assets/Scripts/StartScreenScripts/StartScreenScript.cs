using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public SceneTransitionScript transitionScene;
    public void PlayButton()
    {
        //transitionScene.Darken();
        SceneManager.LoadScene("MainScene");
    }

    public void CreditsButton()
    {
       SceneManager.LoadScene("CreditsScreen"); 
    }

    public void StartScreenButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
