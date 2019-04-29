using System;
using UnityEngine;

[Serializable]
public class Round
{
    AudioController m_AudioController;
    RythmInfo m_Rythm;

    AudioClip m_Background;
    AudioClip m_Sample;

    float m_StartTime = -1f;
    int m_Ticks = 0;

    public bool Finished
    {
        get
        {
            return CurrentTime >= m_Rythm.Length && TotalTicks == m_Rythm.Count;
        }
    }

    public int TotalTicks
    {
        get
        {
            return m_Ticks;
        }
    }

    float CurrentTime
    {
        get
        {
            return Time.time - m_StartTime;
        }
    }

    public Round(
           RythmInfo _Rythm,
           AudioClip _Background,
           AudioClip _Sample,
           AudioController _AudioController
        )
    {
        m_Rythm = _Rythm;
        m_Background = _Background;
        m_Sample = _Sample;
        m_AudioController = _AudioController;
    }

    public void Start()
    {
        m_StartTime = Time.time;
        m_AudioController.PlayBackground(m_Background);
    }

    public void Update()
    {
        int ticks = m_Rythm.ToTicks(CurrentTime);

        if (ticks != m_Ticks)
            m_AudioController.Play(m_Sample);

        m_Ticks = ticks;
    }

    public void Stop()
    {
        m_AudioController.StopBackground();
    }
}
