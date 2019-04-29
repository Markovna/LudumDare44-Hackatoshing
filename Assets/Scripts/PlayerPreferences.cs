using System;
using UnityEngine;

public static class PlayerPreferences
{
    const string MUSIC_VOLUME_KEY = "MUSIC_VOLUME";
    const float MUSIC_VOLUME_DEFAULT = .8f;

    const string SOUNDS_VOLUME_KEY = "SOUNDS_VOLUME";
    const float SOUNDS_VOLUME_DEFAULT = .8f;

    const string DIFFICULTY_KEY = "DIFFICULTY";
    const int DIFFICULTY_DEFAULT = 0;

    const string GRAPHICS_KEY = "GRAPHICS";
    const int GRAPHICS_DEFAULT = 2;

    const string KEYBOARD_KEY = "KEYBOARD";
    const KeyboardOptions KEYBOARD_DEFAULT = KeyboardOptions.ARROWS;

    const string MOUSE_KEY = "MOUSE";
    const MouseOptions MOUSE_DEFAULT = MouseOptions.LBM;

    public static float SoundsVolume
    {
        get { return GetFloat(SOUNDS_VOLUME_KEY, SOUNDS_VOLUME_DEFAULT); }
        set { SetFloat(SOUNDS_VOLUME_KEY, value); }
    }

    public static float MusicVolume
    {
        get { return GetFloat(MUSIC_VOLUME_KEY, MUSIC_VOLUME_DEFAULT);  }
        set { SetFloat(MUSIC_VOLUME_KEY, value); }
    }

    public static int DifficultyLevel
    {
        get { return GetInt(DIFFICULTY_KEY, DIFFICULTY_DEFAULT); }
        set { SetInt(DIFFICULTY_KEY, value); }
    }

    public static int GraphicsLevel
    {
        get { return GetInt(GRAPHICS_KEY, GRAPHICS_DEFAULT); }
        set { SetInt(GRAPHICS_KEY, value); }
    }

    public static KeyboardOptions KeyboardOptions
    {
        get { return (KeyboardOptions) GetInt(KEYBOARD_KEY, (int) KEYBOARD_DEFAULT); }
        set { SetInt(KEYBOARD_KEY, (int) value); }
    }


    public static MouseOptions MouseOptions
    {
        get { return (MouseOptions)GetInt(MOUSE_KEY, (int)MOUSE_DEFAULT); }
        set { SetInt(MOUSE_KEY, (int)value); }
    }

    static int GetInt(string _Key, int _Default)
    {
        if (!PlayerPrefs.HasKey(_Key))
        {
            PlayerPrefs.SetInt(_Key, _Default);
            return _Default;
        }
        return PlayerPrefs.GetInt(_Key, _Default);
    }

    static float GetFloat(string _Key, float _Default)
    {
        if (!PlayerPrefs.HasKey(_Key))
        {
            PlayerPrefs.SetFloat(_Key, _Default);
            return _Default;
        }
        return PlayerPrefs.GetFloat(_Key, _Default);
    }

    static void SetInt(string _Key, int _Value)
    {
        PlayerPrefs.SetInt(_Key, _Value);
    }

    static void SetFloat(string _Key, float _Value)
    {
        PlayerPrefs.SetFloat(_Key, _Value);
    }
}

public enum KeyboardOptions
{
    ASWD,
    ARROWS
}

public enum MouseOptions
{
    LBM,
    RBM
}
