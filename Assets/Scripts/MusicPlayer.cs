using System;
using UnityEngine;

public class MusicPlayer : Singleton<MusicPlayer>
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }
    
    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
