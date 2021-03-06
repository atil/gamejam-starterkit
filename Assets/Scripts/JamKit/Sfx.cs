using System.Collections.Generic;
using UnityEngine;

public class Sfx : SingletonBehaviour<Sfx>
{
    [SerializeField]
    private AudioSource _commonAudioSource;
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

    private float _musicVolume;

    private void Start()
    {
        _musicVolume = _musicAudioSource.volume;
    }

    public void ChangeMusicTrack(AudioClip musicClip)
    {
        _musicAudioSource.clip = musicClip;
        _musicAudioSource.volume = _musicVolume;
    }

    public void FadeOutMusic(float duration)
    {
        AnimationCurve linearCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        Curve.Tween(linearCurve,
            duration,
            t =>
            {
                _musicAudioSource.volume = Mathf.Lerp(_musicVolume, 0f, t);
            },
            () =>
            {
                _musicAudioSource.volume = 0f;
            });
    }

    public void Jump()
    {
        _commonAudioSource.PlayOneShot(_jumpClip);
    }

    public void Land()
    {
        _commonAudioSource.PlayOneShot(_landClip);
    }

    public void LandFromHeight()
    {
        _commonAudioSource.PlayOneShot(_landFromHeightClip);
    }

    public void Footstep()
    {
        _commonAudioSource.PlayOneShot(_footsteps[0]);

        AudioClip playedSound = _footsteps[0];

        _footsteps.RemoveAt(0);
        _footsteps.Shuffle();
        _footsteps.Add(playedSound);
    }

    public void Button()
    {
        _commonAudioSource.PlayOneShot(_buttonClip);
    }
}

