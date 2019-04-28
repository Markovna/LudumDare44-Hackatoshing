using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionsController : MonoBehaviour
{
    [SerializeField] Color m_NormalColor;
    [SerializeField] Color m_HighlightedColor;

    [Header("Difficulty")]
    [SerializeField] Text m_DifficultyLow;
    [SerializeField] Text m_DifficultyNormal;
    [SerializeField] Text m_DifficultyHigh;
    [SerializeField] GameObject m_DifficultyMenu;

    [Header("Graphics")]
    [SerializeField] Text m_GraphicsLow;
    [SerializeField] Text m_GraphicsNormal;
    [SerializeField] Text m_GraphicsHigh;
    [SerializeField] Text m_GraphicsUltra;
    [SerializeField] GameObject m_GraphicsMenu;

    [Header("Keyboard")]
    [SerializeField] Text m_KeyboardArrows;
    [SerializeField] Text m_KeyboardAwsd;
    [SerializeField] GameObject m_KeyboardMenu;

    [Header("Mouse")]
    [SerializeField] Text m_MouseLeft;
    [SerializeField] Text m_MouseRight;
    [SerializeField] GameObject m_MouseMenu;

    public void OpenDifficulty()
    {
        UpdateDifficulty();

        OpenMenu(m_DifficultyMenu);
    }

    public void OpenGraphics()
    {
        UpdateGraphics();

        OpenMenu(m_GraphicsMenu);
    }

    public void OpenKeyboard()
    {
        UpdateKeyboard();

        OpenMenu(m_KeyboardMenu);
    }

    public void OpenMouse()
    {
        UpdateMouse();

        OpenMenu(m_MouseMenu);
    }

    public void SetKeyboardOption(int _Option)
    {
        PlayerPreferences.KeyboardOptions = (KeyboardOptions) _Option;
        UpdateKeyboard();
    }

    public void SetMouseOption(int _Option)
    {
        PlayerPreferences.MouseOptions = (MouseOptions)_Option;
        UpdateMouse();
    }

    public void SetDifficultyLevel(int _Level)
    {
        PlayerPreferences.DifficultyLevel = _Level;
        UpdateDifficulty();
    }

    public void SetGraphicsLevel(int _Level)
    {
        PlayerPreferences.GraphicsLevel = _Level;
        UpdateGraphics();
    }

    void OpenMenu(GameObject _Menu)
    {
        m_DifficultyMenu.SetActive(m_DifficultyMenu == _Menu);
        m_GraphicsMenu.SetActive(m_GraphicsMenu == _Menu);
        m_KeyboardMenu.SetActive(m_KeyboardMenu == _Menu);
        m_MouseMenu.SetActive(m_MouseMenu == _Menu);
    }

    void UpdateDifficulty()
    {
        int difficulty = PlayerPreferences.DifficultyLevel;
        m_DifficultyLow.color = difficulty == 0 ? m_HighlightedColor : m_NormalColor;
        m_DifficultyNormal.color = difficulty == 1 ? m_HighlightedColor : m_NormalColor;
        m_DifficultyHigh.color = difficulty == 2 ? m_HighlightedColor : m_NormalColor;
    }

    void UpdateGraphics()
    {
        int graphic = PlayerPreferences.GraphicsLevel;
        m_GraphicsLow.color = graphic == 0 ? m_HighlightedColor : m_NormalColor;
        m_GraphicsNormal.color = graphic == 1 ? m_HighlightedColor : m_NormalColor;
        m_GraphicsHigh.color = graphic == 2 ? m_HighlightedColor : m_NormalColor;
        m_GraphicsUltra.color = graphic == 3 ? m_HighlightedColor : m_NormalColor;
    }

    void UpdateKeyboard()
    {
        KeyboardOptions option = PlayerPreferences.KeyboardOptions;
        m_KeyboardArrows.color = option == KeyboardOptions.ARROWS ? m_HighlightedColor : m_NormalColor;
        m_KeyboardAwsd.color = option == KeyboardOptions.ASWD ? m_HighlightedColor : m_NormalColor;
    }

    void UpdateMouse()
    {
        MouseOptions option = PlayerPreferences.MouseOptions;
        m_MouseLeft.color = option == MouseOptions.LBM ? m_HighlightedColor : m_NormalColor;
        m_MouseRight.color = option == MouseOptions.RBM ? m_HighlightedColor : m_NormalColor;
    }
}
