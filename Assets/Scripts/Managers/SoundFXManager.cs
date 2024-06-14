using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource SFXObject;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void PlaySFXClip(AudioClip clip, Transform spawnTransform, float volume)
    {
        AudioSource audioSrc = Instantiate(SFXObject);
        audioSrc.clip = clip;
        audioSrc.volume = volume;   
        audioSrc.Play();
        float clipLength = audioSrc.clip.length;
        Destroy(audioSrc.gameObject, clipLength);
    }

    public void PlayRandomSFXClip(AudioClip[] clips, Transform spawnTransform, float volume)
    {
        int rand_index = Random.Range(0, clips.Length);
       // if()
            AudioSource audioSrc = Instantiate(SFXObject);
        audioSrc.clip = clips[rand_index];
        audioSrc.volume = volume;
        audioSrc.Play();
        float clipLength = audioSrc.clip.length;
        Destroy(audioSrc.gameObject, clipLength);
        
    }
}
