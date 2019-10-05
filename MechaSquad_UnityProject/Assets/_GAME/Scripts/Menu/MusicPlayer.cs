using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Andrew Seba
/// Description: Helps play and change music.
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    [Tooltip("Place whatever song you want in this spot to listen first.")]
    public AudioClip startSong;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if(audioSrc == null)
        {
            audioSrc = gameObject.AddComponent<AudioSource>();
        }

        if(startSong != null)
        {
            audioSrc.clip = startSong;
            audioSrc.Play();
        }
    }

    public static void PlaySong(AudioClip audio)
    {

    }
}
