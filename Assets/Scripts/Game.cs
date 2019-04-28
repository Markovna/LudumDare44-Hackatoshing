using System;
using UnityEngine;

[Serializable]
public class Game
{
    AudioController m_AudioController;
    TimerController m_TimerController;
    RythmInfo m_Rythm;

    float m_StartTime = -1f;
    int m_Ticks = -1;

    float CurrentTime
    {
        get
        {
            return Time.time - m_StartTime;
        }
    }

    public Game(
           RythmInfo _Rythm,
           AudioController _AudioController,
           TimerController _TimerController
        )
    {
        m_Rythm = _Rythm;
        m_AudioController = _AudioController;
        m_TimerController = _TimerController;
    }

    public void Start()
    {
        m_StartTime = Time.time;
        m_AudioController.PlayBackground();
    }

    public void Update()
    {
        int ticks = m_Rythm.ToTicks(CurrentTime);
        m_TimerController.SetTime(TimeSpan.FromSeconds(ticks));

        if (ticks != m_Ticks)
            m_AudioController.PlayTick();

        m_Ticks = ticks;
    }

    public void Stop()
    {
        m_AudioController.StopBackground();
    }
}
