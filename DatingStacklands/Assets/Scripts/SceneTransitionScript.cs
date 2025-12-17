using UnityEngine;

public class SceneTransitionScript : MonoBehaviour
{
    public Animator anim;
    public void Lighten()
    {
        anim.SetTrigger("Light");
    }

    public void Darken()
    {
        anim.SetTrigger("Dark");
    }
}
