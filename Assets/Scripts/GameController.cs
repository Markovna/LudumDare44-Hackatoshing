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

    [SerializeField] TextRandomizer m_CongratsText;
    [SerializeField] GameObject m_Intro;
    [SerializeField] Animator m_IntroAnimator;
    [SerializeField] GameObject m_Menu;

    [SerializeField] TextRandomizer m_IntroText;

    int m_TotalTicks;
    Round m_Round;
    bool m_FirstRound = true;

    private void Awake()
    {
        m_Menu.SetActive(false);
        m_IntroText.SetRandomText();
        m_IntroAnimator.Play("Intro_Start_v1");
        Delay(9f, ShowMenu);
    }

    void ShowMenu()
    {
        m_Intro.SetActive(false);
        m_Menu.SetActive(true);
    }

    public void StartGame()
    {
        m_UI.SetActive(true);

        Play("Default");

        m_TimerController.Reset();

        StartRound();
    }

    public void NextRound()
    {
        Play("Continue");

        Delay(.5f, StartRound);
    }

    void Delay(float _Delay, Action _Action)
    {
        StartCoroutine(DelayCoroutine(_Delay, _Action));
    }

    IEnumerator DelayCoroutine(float _Delay, Action _Action)
    {
        yield return new WaitForSeconds(_Delay);

        if (_Action != null)
            _Action();
    }

    void ShowButtons(bool _Show)
    {
        m_Coninue.gameObject.SetActive(_Show);
        m_Exit.gameObject.SetActive(_Show);
    }

    void StartRound()
    {
        ShowButtons(false);

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

        ShowButtons(true);

        Play("Enough");
    }

    public void Exit()
    {
        if (m_Round != null)
            m_Round.Stop();

        m_TimerController.Reset();

        m_UI.SetActive(false);
    }

    public void ShowCredits()
    {
        Play("Credits");
    }

    void ShowConrgrats()
    {
        m_Animator.Play("Congrats");

        if (m_FirstRound)
            m_CongratsText.SetDefaultText();
        else
            m_CongratsText.SetRandomText();

        m_FirstRound = false;
    }

    void Play(string _State)
    {
        m_Animator.Play(_State);
        m_Animator.Update(0f);
    }

    void Update()
    {
        if (m_Round != null)
        {
            m_Round.Update();

            m_TimerController.SetTime(TimeSpan.FromSeconds(m_TotalTicks + m_Round.TotalTicks));

            if (m_Round.Finished)
            {
                m_TotalTicks += m_Round.TotalTicks;
                m_Round.Stop();

                Delay(.5f, ShowConrgrats);

                m_Round = null;
            }
        }
    }
}
