using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class AudioSourcePool : MonoBehaviour
{
    List<AudioSource> m_Pool;
    int m_InitCount = 10;

    private void Awake()
    {
        m_Pool = GetComponents<AudioSource>().ToList();
        if (m_Pool.Count < m_InitCount)
        {
            int count = m_InitCount - m_Pool.Count;
            for (int i = 0; i < count; i++ )
            {
                m_Pool.Add(gameObject.AddComponent<AudioSource>());
            }
        }

        foreach (var s in m_Pool)
            InitSoure(s);
    }

    public AudioSource GetAudioSource(float _Time)
    {
        AudioSource source = GetAudioSource();
        StartCoroutine(Delay(_Time, () => DestroySource(source)));
        return source;
    }

    public AudioSource GetAudioSource()
    {
        AudioSource source;
        if (m_Pool.Count < 1)
        {
            source = gameObject.AddComponent<AudioSource>();
            InitSoure(source);
            return source;
        }

        source = m_Pool[0];
        InitSoure(source);
        m_Pool.RemoveAt(0);
        return source;
    }

    void InitSoure(AudioSource _Source)
    {
        _Source.playOnAwake = false;
    }

    public void DestroySource(AudioSource _Source)
    {
        _Source.Stop();
        _Source.clip = null;
        m_Pool.Add(_Source);
    }

    IEnumerator Delay(float _Delay, Action _Callback)
    {
        yield return new WaitForSeconds(_Delay);

        if (_Callback != null)
            _Callback();
    }
}
