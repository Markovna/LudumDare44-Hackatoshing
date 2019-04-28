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

    Game m_Game;

    public void StartGame()
    {
        m_Game = new Game(RythmsStore.Instance.GetRythm(), m_AudioController, m_TimerController);
        m_Game.Start();

        m_UI.SetActive(true);
    }

    public void StopGame()
    {
        if (m_Game != null)
            m_Game.Start();

        m_UI.SetActive(false);
    }

    void Update()
    {
        if (m_Game != null)
            m_Game.Update();
    }
}
