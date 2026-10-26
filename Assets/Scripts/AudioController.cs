using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip metallicThump;
    public AudioClip buttonWork;
    public AudioClip buttonFail;
    public AudioClip footsteps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDoorThump()
    {
        audioSource.PlayOneShot(metallicThump, 1f);
    }

    public void DoorButtonPress(bool buttonMoveDoor)
    {
        if (buttonMoveDoor)
        {
            audioSource.PlayOneShot(buttonWork, 1f);
        }
        else
        {
            audioSource.PlayOneShot(buttonFail, 1f);
        }
    }

    public void playFootSteps(bool heavyFootsteps)
    {
        //float footstepsLength = footsteps.clip.length;
        if (heavyFootsteps)
        {
            audioSource.PlayOneShot(footsteps, 0.1f);
        }
        else
        {
            audioSource.PlayOneShot(footsteps, 0.025f);
        }
    }
}
