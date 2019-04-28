using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu()]
public class RythmsStore : SingletonScriptableObject<RythmsStore>
{
    [SerializeField] List<RythmInfo> m_Rythms;

    public RythmInfo GetRythm()
    {
        int index = UnityEngine.Random.Range(0, m_Rythms.Count);
        return m_Rythms[index];
    }
}
