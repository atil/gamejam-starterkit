#define AUDIO_ENABLED

using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    [SerializeField]
    private AudioSource _walkAudioSource;
    [SerializeField]
    private AudioSource _otherAudioSource;
    [SerializeField]
    private AudioSource _musicAudioSource;

    [Space]

    [SerializeField]
    private AudioClip _jumpClip;
    [SerializeField]
    private AudioClip _landClip;
    [SerializeField]
    private AudioClip _landFromHeightClip;
    [SerializeField]
    private AudioClip _buttonClip;

    [SerializeField]
    private List<AudioClip> _footsteps;

    private void Start()
    {
#if !AUDIO_ENABLED
        _musicAudioSource.volume = 0;
#endif
    }

    public void OnMusicVolumeChanged(float normalizedValue)
    {
        _musicAudioSource.volume = normalizedValue;
    }

    public void OnSfxVolumeChanged(float normalizedValue)
    {
        _otherAudioSource.volume = normalizedValue;
    }

    public void Jump()
    {
#if !AUDIO_ENABLED
        return;
#endif
        _otherAudioSource.PlayOneShot(_jumpClip);
    }

    public void Land()
    {
        _otherAudioSource.PlayOneShot(_landClip);
    }

    public void LandFromHeight()
    {
        _otherAudioSource.PlayOneShot(_landFromHeightClip);
    }

    public void Footstep()
    {
#if !AUDIO_ENABLED
        return;
#endif
        _walkAudioSource.PlayOneShot(_footsteps[0]);

        AudioClip playedSound = _footsteps[0];

        _footsteps.RemoveAt(0);
        _footsteps.Shuffle();
        _footsteps.Add(playedSound);
    }

    public void Button()
    {
        _otherAudioSource.PlayOneShot(_buttonClip);
    }
}

