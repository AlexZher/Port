﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    public static AudioSource audioSource;
    
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioSource.volume = 0.1f;
        audioClips.Add(AudioClipName.Explosion, 
            Resources.Load<AudioClip>("Explosion"));
        audioClips.Add(AudioClipName.MenuButtonClick,
            Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.DestroyerBump,
            Resources.Load<AudioClip>("DestroyerBump"));
        audioClips.Add(AudioClipName.RightBucket,
             Resources.Load<AudioClip>("Correct"));

    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
        
    }


}
