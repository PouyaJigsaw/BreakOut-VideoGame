using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class AudioManager 
{

    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();


    public static bool Initialized
    {
        get
        {
            return initialized;
        }
    }


    public static void  Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        audioClips.Add(AudioClipName.BlockDestroy, Resources.Load<AudioClip>("Explosion"));
        audioClips.Add(AudioClipName.ButtonClick, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.GameOver, Resources.Load<AudioClip>("BurgerDeath"));
        audioClips.Add(AudioClipName.BallDown, Resources.Load<AudioClip>("TeddyShot"));


    }


    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
