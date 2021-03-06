﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSourcePool m_AudioSourcePool;
    [SerializeField] AudioMixerGroup m_Mixer;

    AudioSource m_Background;

    public void Play(AudioClip _Clip)
    {
        AudioSource source = m_AudioSourcePool.GetAudioSource(_Clip.length);
        source.clip = _Clip;
        source.outputAudioMixerGroup = m_Mixer;
        source.volume = PlayerPreferences.SoundsVolume;
        source.loop = false;
        source.playOnAwake = false;
        source.Play();
    }

    public void PlayBackground(AudioClip _Clip)
    {
        m_Background = m_AudioSourcePool.GetAudioSource();
        m_Background.clip = _Clip;
        m_Background.outputAudioMixerGroup = m_Mixer;
        m_Background.volume = PlayerPreferences.MusicVolume;
        m_Background.loop = false;
        m_Background.Play();
    }

    public void StopBackground()
    {
        m_Background.Stop();
        m_AudioSourcePool.DestroySource(m_Background);
    }
}
