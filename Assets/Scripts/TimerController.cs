using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour
{
    [SerializeField] TimerSection m_Hours;
    [SerializeField] TimerSection m_Minutes;
    [SerializeField] TimerSection m_Seconds;

    [SerializeField] Animator m_Animator;

    bool m_MinutesShown;
    bool m_HoursShown;

    private void Awake()
    {
        m_Hours.Hide();
        m_Minutes.Hide();
        m_Seconds.Hide();
    }

    public void Hide()
    {
        m_MinutesShown = false;
        m_HoursShown = false;

        m_Hours.Reset();
        m_Minutes.Reset();
        m_Seconds.Reset();
    }

    public void SetTime(TimeSpan _Time)
    {
        int seconds = _Time.Seconds;
        int minutes = _Time.Minutes;
        int hours = _Time.Hours;

        m_Seconds.Set(seconds);

        bool showMinutes = minutes > 0 || hours > 0;
        bool showHours = hours > 0;

        if (showMinutes)
            m_Minutes.Set(minutes);
        else
            m_Minutes.Hide();

        if (showHours)
            m_Hours.Set(hours);
        else
            m_Hours.Hide();

        if (showHours != m_HoursShown || showMinutes != m_MinutesShown)
        {
            float val = showHours ? 1f : (showMinutes ? .5f : 0f);
            StartCoroutine(Animate(m_Animator.GetFloat("Blend"), val, .5f));
        }

        m_MinutesShown = showMinutes;
        m_HoursShown = showHours;
    }

    IEnumerator Animate(float _From, float _To, float _Duration)
    {
        float start = Time.time;
        float curr = 0f;
        while(curr < _Duration)
        {
            float phase = curr / _Duration;
            m_Animator.SetFloat("Blend", Mathf.Lerp(_From, _To, phase));

            yield return null;
            curr = Time.time - start;
        }

        m_Animator.SetFloat("Blend", _To);
    }
}
