// Script para gestionar audio
// Assets/Scripts/Rooms/PurpleRoom/ChildhoodAudio.cs
using UnityEngine;

public class ChildhoodAudio : MonoBehaviour
{
    public AudioClip laughter;
    public AudioClip toySounds;
    public AudioClip playfulMusic;
    
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomChildhoodSound();
    }
    
    void PlayRandomChildhoodSound()
    {
        AudioClip[] clips = { laughter, toySounds, playfulMusic };
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        
        if (randomClip != null && audioSource != null)
        {
            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}