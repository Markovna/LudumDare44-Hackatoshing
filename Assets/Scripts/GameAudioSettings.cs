using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class GameAudioSettings : ScriptableObject
{
    static string PATH = "GameAudioSettings";

    static GameAudioSettings m_Instance = null;
    public static GameAudioSettings Instance
    {
        get
        {
            if (!m_Instance)
            {
                m_Instance = Resources.Load<GameAudioSettings>(PATH);
            }

            return m_Instance;
        }
    }

    [Serializable]
    public class LevelInfo
    {
        public List<RythmInfo> Rhythms;
        public List<AudioClip> Backgrounds;

        public RythmInfo GetRythm()
        {
            int index = UnityEngine.Random.Range(0, Rhythms.Count);
            return Rhythms[index];
        }

        public AudioClip GetBackground()
        {
            int index = UnityEngine.Random.Range(0, Backgrounds.Count);
            return Backgrounds[index];
        }
    }

    [SerializeField] List<LevelInfo> m_Levels;
    [SerializeField] List<AudioClip> m_Samples;

    public RythmInfo GetRythm(int _Level)
    {
        return m_Levels[_Level].GetRythm();
    }

    public AudioClip GetSample()
    {
        int index = UnityEngine.Random.Range(0, m_Samples.Count);
        return m_Samples[index];
    }

    public AudioClip GetBackground(int _Level)
    {
        return m_Levels[_Level].GetBackground();
    }
}

