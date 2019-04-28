using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TimerSection
{
    [Serializable]
    public class Digit
    {
        [SerializeField] Animator m_Animator;
        [SerializeField] Text m_Text;

        List<string> m_States = new List<string> { "N_Splash_" };

        public void Show(int _Value)
        {
            m_Text.text = _Value.ToString("0");
            m_Animator.Play(GetRandomAnimation(true));
        }

        public void Hide()
        {
            m_Animator.Play(GetRandomAnimation(false));
        }

        public void Reset()
        {
            m_Text.text = "";
        }

        string GetRandomAnimation(bool _Open)
        {
            int rand = UnityEngine.Random.Range(0, m_States.Count);
            return m_States[rand] + (_Open ? "Open" : "Close");
        }
    }

    [Serializable]
    public class AnimationDigit
    {
        [SerializeField] List<Digit> m_Digits;

        int m_CurrentIndex;
        int m_CurrentValue = -1;

        public void Reset()
        {
            foreach (var d in m_Digits)
            {
                d.Reset();
            }
            m_CurrentIndex = -1;
            m_CurrentValue = -1;
        }

        public void SetValue(int _Value)
        {
            if (m_CurrentValue == _Value)
                return;

            if (m_CurrentIndex >= 0 && m_CurrentIndex < m_Digits.Count)
                m_Digits[m_CurrentIndex].Hide();

            m_CurrentIndex = (m_CurrentIndex + 1) % m_Digits.Count;
            m_Digits[m_CurrentIndex].Show(_Value);

            m_CurrentValue = _Value;
        }

        public void Hide()
        {
            if (m_CurrentIndex >= 0 && m_CurrentIndex < m_Digits.Count)
            {
                m_Digits[m_CurrentIndex].Hide();
                m_CurrentIndex = -1;
                m_CurrentValue = -1;
            }
        }
    }

    [SerializeField] AnimationDigit m_LeftDigit;
    [SerializeField] AnimationDigit m_RightDigit;
    [SerializeField] Text m_Label;

    public void Set(int _Value)
    {
        int leftVal = _Value / 10;
        int rightVal = _Value % 10;

        m_LeftDigit.SetValue(leftVal);
        m_RightDigit.SetValue(rightVal);
        m_Label.gameObject.SetActive(true);
    }

    public void Hide()
    {
        m_LeftDigit.Hide();
        m_RightDigit.Hide();
        m_Label.gameObject.SetActive(false);
    }

    public void Reset()
    {
        m_LeftDigit.Reset();
        m_RightDigit.Reset();
        m_Label.gameObject.SetActive(false);
    }
}
