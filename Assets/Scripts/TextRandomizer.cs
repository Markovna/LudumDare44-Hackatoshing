using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextRandomizer : MonoBehaviour
{
    [SerializeField] Text m_Text;
    [SerializeField] List<string> m_Texts;

    public void SetRandomText()
    {
        m_Text.text = m_Texts[Random.Range(0, m_Texts.Count)].Replace("\\n", "\n");
    }

    public void SetDefaultText()
    {
        m_Text.text = m_Texts[0].Replace("\\n", "\n");
    }
}
