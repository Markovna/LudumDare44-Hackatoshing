using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] AudioController m_AudioController;
    [SerializeField] TimerController m_TimerController;
    [SerializeField] GameObject m_UI;
    [SerializeField] float m_Seconds = 30f;
    [SerializeField] float m_RealSeconds = 15f;

    float m_StartTime = -1f;
    float m_Scale;

    int m_LastSeconds = -1;

    public void StartGame()
    {
        m_StartTime = Time.time;
        m_Scale = m_Seconds / m_RealSeconds;

        m_UI.SetActive(true);

        m_AudioController.PlayBackground();
    }

    public void StopGame()
    {
        m_StartTime = -1;

        m_UI.SetActive(false);

        m_AudioController.StopBackground();
    }

    void Update()
    {
        if (m_StartTime < 0)
            return;

        float current = Time.time - m_StartTime;
        TimeSpan time = TimeSpan.FromSeconds(current* m_Scale);

        int sec = time.Seconds;
        if (sec != m_LastSeconds)
            m_AudioController.PlayHit();

        m_LastSeconds = sec;

        m_TimerController.SetTime(time);
    }
}
