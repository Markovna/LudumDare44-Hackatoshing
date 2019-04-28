using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu()]
public class RythmsStore : ScriptableObject
{
    static string PATH = "RythmsStore";

    static RythmsStore m_Instance = null;
    public static RythmsStore Instance
    {
        get
        {
            if (!m_Instance) { 
                m_Instance = Resources.Load<RythmsStore>(PATH);
            }

            return m_Instance;
        }
    }

    [SerializeField] List<RythmInfo> m_Rythms;

    public RythmInfo GetRythm()
    {
        int index = UnityEngine.Random.Range(0, m_Rythms.Count);
        return m_Rythms[index];
    }
}
