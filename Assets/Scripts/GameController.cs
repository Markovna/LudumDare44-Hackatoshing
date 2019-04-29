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
    [SerializeField] Animator m_Animator;

    [SerializeField] GameObject m_Coninue;
    [SerializeField] GameObject m_Exit;

    int m_TotalTicks;

    Round m_Round;

    public void StartGame()
    {
        m_UI.SetActive(true);

        m_Animator.Play("Default");
        m_Animator.Update(0f);

        m_TimerController.Reset();

        StartRound();
    }

    public void NextRound()
    {
        m_Animator.Play("Continue");
        m_Animator.Update(0f);

        StartRound();
    }

    void StartRound()
    {
        m_Coninue.gameObject.SetActive(false);
        m_Exit.gameObject.SetActive(false);

        m_TimerController.SetTime(TimeSpan.FromSeconds(m_TotalTicks), true);

        m_Round = new Round(
                GameAudioSettings.Instance.GetRythm(PlayerPreferences.DifficultyLevel),
                GameAudioSettings.Instance.GetBackground(PlayerPreferences.DifficultyLevel),
                GameAudioSettings.Instance.GetSample(),
                m_AudioController
                );
        m_Round.Start();
    }

    public void StopGame()
    {
        if (m_Round != null)
            m_Round.Stop();

        m_Coninue.gameObject.SetActive(true);
        m_Exit.gameObject.SetActive(true);

        m_Animator.Play("Default");
        m_Animator.Update(0f);

        m_TimerController.Reset();

        m_UI.SetActive(false);
    }

    void Update()
    {
        if (m_Round != null && !m_Round.Finished)
        {
            m_Round.Update();

            m_TimerController.SetTime(TimeSpan.FromSeconds(m_TotalTicks + m_Round.TotalTicks));

            if (m_Round.Finished)
            {
                m_TotalTicks += m_Round.TotalTicks;
                m_Round.Stop();

                m_Animator.Play("Congrats");

                m_Round = null;
            }
        }
    }
}
