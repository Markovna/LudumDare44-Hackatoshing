using UnityEngine;
using System.Collections.Generic;

public class StateListBehaviour : StateMachineBehaviour
{
    [SerializeField] List<string> m_OpenStates;
    [SerializeField] List<string> m_CloseStates;

    public string GetOpenState()
    {
        int index = Random.Range(0, m_OpenStates.Count);
        return m_OpenStates[index];
    }

    public string GetCloseState()
    {
        int index = Random.Range(0, m_CloseStates.Count);
        return m_CloseStates[index];
    }
}
