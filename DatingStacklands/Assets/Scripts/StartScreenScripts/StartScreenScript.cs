using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CreditsButton()
    {
       SceneManager.LoadScene("CreditsScene"); 
    }

    public void StartScreenButton()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
