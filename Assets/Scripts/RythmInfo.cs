using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu()]
public class RythmInfo : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] List<float> m_Ticks;

    List<float> m_SortedTicks;

    public int Count
    {
        get
        { 
            return m_Ticks.Count;
        }
    }

    public void OnAfterDeserialize()
    {
        m_SortedTicks = m_Ticks.OrderBy(_T => _T).ToList();
        
    }

    public void OnBeforeSerialize()
    {
    }

    public int ToTicks(float _Time)
    {
        return BinarySearch(m_SortedTicks, _Time);
    }

    static int BinarySearch<T>(IList<T> _List, T _Value)
    {
        if (_List == null)
            return -1;

        var comp = Comparer<T>.Default;
        int lo = 0, hi = _List.Count - 1;
        while (lo < hi)
        {
            int m = (hi + lo) / 2;
            if (comp.Compare(_List[m], _Value) < 0) lo = m + 1;
            else hi = m - 1;
        }
        if (comp.Compare(_List[lo], _Value) < 0)
            lo++;

        return lo;
    }
}
