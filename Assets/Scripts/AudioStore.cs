using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu()]
public class AudioStore : ScriptableObject
{
    [SerializeField] List<AudioClip> m_BackgroudClips;
    [SerializeField]AudioClip m_HitClip;

    public AudioClip GetRandomBackground()
    {
        int index = Random.Range(0, m_BackgroudClips.Capacity);
        return m_BackgroudClips[index];
    }

    public AudioClip GetHit()
    {
        return m_HitClip;
    }
}
