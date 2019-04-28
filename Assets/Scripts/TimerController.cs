using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour
{
    [SerializeField] Text m_SecondsText;
    [SerializeField] Text m_MinutesText;
    [SerializeField] Text m_HoursText;

    [SerializeField] Text m_SecondsLabel;
    [SerializeField] Text m_MinutesLabel;
    [SerializeField] Text m_HoursLabel;

    private void Awake()
    {
        m_SecondsText.text = "";
        m_MinutesText.text = "";
        m_HoursText.text = "";
    }

    public void SetTime(TimeSpan _Time)
    {
        int seconds = _Time.Seconds;
        int minutes = _Time.Minutes;
        int hours = _Time.Hours;

        m_SecondsText.text = seconds.ToString();
        m_MinutesText.text = minutes > 0 || hours > 0 ? minutes.ToString() : "";
        m_HoursText.text = hours > 0 ? hours.ToString() : "";

        m_SecondsLabel.gameObject.SetActive(!string.IsNullOrEmpty(m_SecondsText.text));
        m_MinutesLabel.gameObject.SetActive(!string.IsNullOrEmpty(m_MinutesText.text));
        m_HoursLabel.gameObject.SetActive(!string.IsNullOrEmpty(m_HoursText.text));
    }
}
