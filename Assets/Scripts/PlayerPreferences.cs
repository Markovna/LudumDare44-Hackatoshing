using System;
using UnityEngine;

public static class PlayerPreferences
{
    const string DIFFICULTY_KEY = "DIFFICULTY";
    const int DIFFICULTY_DEFAULT = 1;

    const string GRAPHICS_KEY = "GRAPHICS";
    const int GRAPHICS_DEFAULT = 2;

    const string KEYBOARD_KEY = "KEYBOARD";
    const KeyboardOptions KEYBOARD_DEFAULT = KeyboardOptions.ARROWS;

    const string MOUSE_KEY = "MOUSE";
    const MouseOptions MOUSE_DEFAULT = MouseOptions.LBM;

    public static int DifficultyLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey(DIFFICULTY_KEY))
            {
                PlayerPrefs.SetInt(DIFFICULTY_KEY, DIFFICULTY_DEFAULT);
                return DIFFICULTY_DEFAULT;
            }
            return PlayerPrefs.GetInt(DIFFICULTY_KEY, DIFFICULTY_DEFAULT);
        }
        set
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, value);
        }
    }

    public static int GraphicsLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey(GRAPHICS_KEY))
            {
                PlayerPrefs.SetInt(GRAPHICS_KEY, GRAPHICS_DEFAULT);
                return GRAPHICS_DEFAULT;
            }
            return PlayerPrefs.GetInt(GRAPHICS_KEY, GRAPHICS_DEFAULT);
        }
        set
        {
            PlayerPrefs.SetInt(GRAPHICS_KEY, value);
        }
    }

    public static KeyboardOptions KeyboardOptions
    {
        get
        {
            if (!PlayerPrefs.HasKey(KEYBOARD_KEY))
            {
                PlayerPrefs.SetInt(KEYBOARD_KEY, (int) KEYBOARD_DEFAULT);
                return KEYBOARD_DEFAULT;
            }
            return (KeyboardOptions) PlayerPrefs.GetInt(KEYBOARD_KEY, (int) KEYBOARD_DEFAULT);
        }
        set
        {
            PlayerPrefs.SetInt(KEYBOARD_KEY, (int) value);
        }
    }


    public static MouseOptions MouseOptions
    {
        get
        {
            if (!PlayerPrefs.HasKey(MOUSE_KEY))
            {
                PlayerPrefs.SetInt(MOUSE_KEY, (int)MOUSE_DEFAULT);
                return MOUSE_DEFAULT;
            }
            return (MouseOptions) PlayerPrefs.GetInt(MOUSE_KEY, (int)MOUSE_DEFAULT);
        }
        set
        {
            PlayerPrefs.SetInt(MOUSE_KEY, (int) value);
        }
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
