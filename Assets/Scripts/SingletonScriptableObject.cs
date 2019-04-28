using UnityEngine;
using System.Linq;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T m_Instance = null;
    public static T Instance
    {
        get
        {
            if (!m_Instance)
                m_Instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            return m_Instance;
        }
    }
}