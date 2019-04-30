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
    [SerializeField] GameObject m_DifficultyMenu;

    [Header("Graphics")]
    [SerializeField] Text m_GraphicsLow;
    [SerializeField] Text m_GraphicsNormal;
    [SerializeField] Text m_GraphicsHigh;
    [SerializeField] GameObject m_GraphicsMenu;

    [Header("Sound")]
    [SerializeField] Slider m_MusicSlider;
    [SerializeField] Slider m_SoundSlider;
    [SerializeField] GameObject m_SoundMenu;

    [Header("Keyboard")]
    [SerializeField] Text m_KeyboardArrows;
    [SerializeField] Text m_KeyboardAwsd;
    [SerializeField] GameObject m_KeyboardMenu;

    [Header("Mouse")]
    [SerializeField] Text m_MouseLeft;
    [SerializeField] Text m_MouseRight;
    [SerializeField] GameObject m_MouseMenu;

    public void CloseOptions()
    {
        gameObject.SetActive(false);
        CloseMenus();
    }

    public void OpenSound()
    {
        UpdateSound();

        OpenMenu(m_SoundMenu);
    }

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

    void SaveSoundSettings()
    {
        PlayerPreferences.MusicVolume = m_MusicSlider.value;
        PlayerPreferences.SoundsVolume = m_SoundSlider.value;
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
        RenderPostEffect.SetGraphicLevel(_Level);
        UpdateGraphics();
    }

    void CloseMenus()
    {
        OpenMenu(null);
    }

    void OpenMenu(GameObject _Menu)
    {
        m_DifficultyMenu.SetActive(m_DifficultyMenu == _Menu);
        m_GraphicsMenu.SetActive(m_GraphicsMenu == _Menu);
        m_KeyboardMenu.SetActive(m_KeyboardMenu == _Menu);
        m_MouseMenu.SetActive(m_MouseMenu == _Menu);

        bool soundOpened = m_SoundMenu.gameObject.activeSelf;
        bool showSound = m_SoundMenu == _Menu;
        if (soundOpened && !showSound)
            SaveSoundSettings();

        m_SoundMenu.SetActive(showSound);
    }

    void UpdateSound()
    {
        float musicVolume = PlayerPreferences.MusicVolume;
        float soundVolume = PlayerPreferences.SoundsVolume;

        m_MusicSlider.value = musicVolume;
        m_SoundSlider.value = soundVolume;
    }

    void UpdateDifficulty()
    {
        int difficulty = PlayerPreferences.DifficultyLevel;
        m_DifficultyLow.color = difficulty == 0 ? m_HighlightedColor : m_NormalColor;
        m_DifficultyNormal.color = difficulty == 1 ? m_HighlightedColor : m_NormalColor;
    }

    void UpdateGraphics()
    {
        int graphic = PlayerPreferences.GraphicsLevel;
        m_GraphicsLow.color = graphic == 0 ? m_HighlightedColor : m_NormalColor;
        m_GraphicsNormal.color = graphic == 1 ? m_HighlightedColor : m_NormalColor;
        m_GraphicsHigh.color = graphic == 2 ? m_HighlightedColor : m_NormalColor;
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
