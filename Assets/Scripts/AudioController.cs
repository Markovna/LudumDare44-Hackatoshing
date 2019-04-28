﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSourcePool m_AudioSourcePool;
    [SerializeField] AudioMixerGroup m_Mixer;
    [SerializeField] AudioStore m_Store;
    AudioSource m_Background;

    [SerializeField] float m_HitFrequency;

    float m_LastHit;

    public void PlayBackground()
    {
        m_Background = m_AudioSourcePool.GetAudioSource();
        m_Background.clip = m_Store.GetRandomBackground();
        m_Background.outputAudioMixerGroup = m_Mixer;
        m_Background.loop = true;
        m_Background.Play();
    }

    public void StopBackground()
    {
        m_Background.Stop();
        m_AudioSourcePool.DestroySource(m_Background);
    }

    public void PlayHit()
    {
        AudioClip clip = m_Store.GetHit();
        AudioSource source = m_AudioSourcePool.GetAudioSource(clip.length);
        source.clip = clip;
        source.outputAudioMixerGroup = m_Mixer;
        source.Play();
    }
}
