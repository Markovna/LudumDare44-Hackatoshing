using System;
using UnityEngine;

[Serializable]
public class Round
{
    AudioController m_AudioController;
    RythmInfo m_Rythm;

    float m_StartTime = -1f;
    int m_Ticks = -1;
    float m_SoundOffset = .3f;

    public bool Finished
    {
        get
        {
            return m_Ticks == m_Rythm.Count;
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
           AudioController _AudioController
        )
    {
        m_Rythm = _Rythm;
        m_AudioController = _AudioController;
    }

    public void Start()
    {
        m_StartTime = Time.time;
        m_AudioController.PlayBackground();
    }

    public void Update()
    {
        int ticks = m_Rythm.ToTicks(CurrentTime);

        if (ticks != m_Ticks)
            m_AudioController.PlayTick();

        m_Ticks = ticks;
    }

    public void Stop()
    {
        m_AudioController.StopBackground();
    }
}
