using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;

    //sounds
    public AudioClip clickSound;
    public AudioClip mergingSound;
    public AudioClip mergedSound;
    public AudioClip warpSound;
    public AudioClip bKSound;

    public void ClickSoundPlay()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void mergingSoundPlay()
    {
        audioSource.PlayOneShot(mergingSound);
    }
    
    public void mergedSoundPlay()
    {
        audioSource.PlayOneShot(mergedSound);
    }

    public void warpSoundPlay()
    {
        audioSource.PlayOneShot(warpSound);
    }
}
