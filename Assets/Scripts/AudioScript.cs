using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour 
{
    [SerializeField]private AudioSource[] audioSources;
    [SerializeField]private AudioClip[] gunShots;
    [SerializeField]private AudioClip[] emptyGuns;

    public void PlaySound_GunShot(int soundID, int audioSourceID)
    {
        audioSources[audioSourceID].clip = gunShots[soundID];
        audioSources[audioSourceID].Play();
        audioSources[audioSourceID].Play(44100);
    }

    public void PlaySound_EmptyGun(int soundID, int audioSourceID)
    {
        audioSources[audioSourceID].clip = emptyGuns[soundID];
        audioSources[audioSourceID].Play();
        audioSources[audioSourceID].Play(44100);
    }
}
