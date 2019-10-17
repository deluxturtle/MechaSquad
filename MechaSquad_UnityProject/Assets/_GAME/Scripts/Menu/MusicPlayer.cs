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
    [Tooltip("Song to play during battle.")]
    public AudioClip battleSong;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if(audioSrc == null)
        {
            audioSrc = gameObject.AddComponent<AudioSource>();
            audioSrc.loop = true;
        }

        if(startSong != null)
        {
            audioSrc.clip = startSong;
            audioSrc.Play();
        }
    }

    public void PlaySong(AudioClip audio)
    {
        //TODO: Make a fade? that would be cool.
        audioSrc.clip = audio;
        audioSrc.Play();
    }

    /// <summary>
    /// Quick play for battlesong.
    /// </summary>
    public void PlayBattleSong()
    {
        audioSrc.clip = battleSong;
        audioSrc.Play();
    }

    public void PlayMenuSong()
    {
        audioSrc.clip = startSong;
        audioSrc.Play();
    }
}
