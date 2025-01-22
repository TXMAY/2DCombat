using CustomUtillity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingleTon<SoundManager>
{
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] AudioSource bgmAudioSource;

    public void PlaySFXClip(AudioClip clip, float volume)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.volume = volume;
        sfxAudioSource.PlayOneShot(clip, volume);
    }

    public void PlaySFXFromString(string soundClipName, float volume)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Sound/Enemy/Hurt/{soundClipName}");
        sfxAudioSource.clip = clip;
        sfxAudioSource.PlayOneShot(clip, volume);
    }
}
