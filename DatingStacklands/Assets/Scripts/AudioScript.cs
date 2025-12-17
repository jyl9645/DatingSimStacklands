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
    public AudioClip carddropSound;
    public AudioClip stackSound;
    public AudioClip cardpickSound;
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
    public void cardDropSoundPlay()
    {
        audioSource.PlayOneShot(carddropSound);
    }
    public void cardpickSoundPlay()
    {
        audioSource.PlayOneShot(cardpickSound);
    }
    public void stackSoundPlay()
    {
        audioSource.PlayOneShot(stackSound);
    }
}
