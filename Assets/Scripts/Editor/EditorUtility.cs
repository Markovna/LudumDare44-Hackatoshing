using UnityEngine;
using UnityEditor;

public static class EditorUtility
{
    [MenuItem("Window/GameAudioSettings")]
    static void OpenRythmsStore()
    {
        Selection.activeInstanceID = GameAudioSettings.Instance.GetInstanceID();
    }

    [MenuItem("Assets/Add to GameAudioSettings/Background/Level Normal")]
    public static void AddToGameAudioSettingsNormal()
    {
        AddToGameAudioSettings(0);
    }


    [MenuItem("Assets/Add to GameAudioSettings/Background/Level High")]
    public static void AddToGameAudioSettingsHigh()
    {
        AddToGameAudioSettings(1);
    }

    [MenuItem("Assets/Add to GameAudioSettings/Sample")]
    public static void AddToGameAudioSettingsSample()
    {
        var selectedObjects = Selection.objects;
        if (selectedObjects == null || selectedObjects.Length == 0)
        {
            Debug.Log("No animation clips selected");
            return;
        }

        int clipsNum = selectedObjects.Length;
        for (int c = 0; c < clipsNum; c++)
        {
            if (selectedObjects[c] is AudioClip)
            {
                AddToGameAudioSettingsSamples(selectedObjects[c] as AudioClip);
            }
        }
    }

    public static void AddToGameAudioSettings(int _Level)
    {
        var selectedObjects = Selection.objects;
        if (selectedObjects == null || selectedObjects.Length == 0)
        {
            Debug.Log("No animation clips selected");
            return;
        }

        int clipsNum = selectedObjects.Length;
        for (int c = 0; c < clipsNum; c++)
        {
            if (selectedObjects[c] is AudioClip)
            {
                AddToGameAudioSettings(selectedObjects[c] as AudioClip, _Level);
            }
        }
    }

    public static void AddToGameAudioSettings(AudioClip _Clip, int _Level, bool _ReplaceSameName = true)
    {
        SerializedObject rythmStoreObj = new SerializedObject(GameAudioSettings.Instance);
        SerializedProperty levels = rythmStoreObj.FindProperty("m_Levels");
        SerializedProperty prop;
        if (levels.arraySize < _Level)
            prop = levels.GetArrayElementAtIndex(_Level).FindPropertyRelative("Backgrounds");
        else
        {
            levels.arraySize = _Level + 1;
            prop = levels.GetArrayElementAtIndex(_Level).FindPropertyRelative("Backgrounds");
        }

        bool replaced = false;
        if (_ReplaceSameName)
        {
            for (int i = 0; i < prop.arraySize; i++)
            {
                SerializedProperty element = prop.GetArrayElementAtIndex(i);
                if (element.objectReferenceValue != null && element.objectReferenceValue.name == _Clip.name)
                {
                    Object.DestroyImmediate(element.objectReferenceValue, true);
                    element.objectReferenceValue = _Clip;
                    replaced = true;
                }
            }
        }

        if (!replaced)
        {
            prop.arraySize++;
            prop.GetArrayElementAtIndex(prop.arraySize - 1).objectReferenceValue = _Clip;
        }


        rythmStoreObj.ApplyModifiedProperties();
    }

    public static void AddToGameAudioSettingsSamples(AudioClip _Clip, bool _ReplaceSameName = true)
    {
        SerializedObject rythmStoreObj = new SerializedObject(GameAudioSettings.Instance);
        SerializedProperty prop = rythmStoreObj.FindProperty("m_Samples");

        bool replaced = false;
        if (_ReplaceSameName)
        {
            for (int i = 0; i < prop.arraySize; i++)
            {
                SerializedProperty element = prop.GetArrayElementAtIndex(i);
                if (element.objectReferenceValue != null && element.objectReferenceValue.name == _Clip.name)
                {
                    Object.DestroyImmediate(element.objectReferenceValue, true);
                    element.objectReferenceValue = _Clip;
                    replaced = true;
                }
            }
        }

        if (!replaced)
        {
            prop.arraySize++;
            prop.GetArrayElementAtIndex(prop.arraySize - 1).objectReferenceValue = _Clip;
        }


        rythmStoreObj.ApplyModifiedProperties();
    }

    public static void AddToRythmStore(RythmInfo _Rythm, int _Level, bool _ReplaceSameName = true)
    {
        AssetDatabase.AddObjectToAsset(_Rythm, GameAudioSettings.Instance);
        AssetDatabase.SaveAssets();

        SerializedObject rythmStoreObj = new SerializedObject(GameAudioSettings.Instance);
        SerializedProperty levels = rythmStoreObj.FindProperty("m_Levels");
        SerializedProperty prop;
        if (levels.arraySize < _Level)
            prop = levels.GetArrayElementAtIndex(_Level).FindPropertyRelative("Rhythms");
        else
        {
            levels.arraySize = _Level + 1;
            prop = levels.GetArrayElementAtIndex(_Level).FindPropertyRelative("Rhythms");
        }

        bool replaced = false;
        if (_ReplaceSameName)
        {
            for (int i = 0; i < prop.arraySize; i++)
            {
                SerializedProperty element = prop.GetArrayElementAtIndex(i);
                if (element.objectReferenceValue != null && element.objectReferenceValue.name == _Rythm.name)
                {
                    Object.DestroyImmediate(element.objectReferenceValue, true);
                    element.objectReferenceValue = _Rythm;
                    replaced = true;
                }
            }
        }

        if (!replaced)
        { 
            prop.arraySize++;
            prop.GetArrayElementAtIndex(prop.arraySize - 1).objectReferenceValue = _Rythm;
        }


        rythmStoreObj.ApplyModifiedProperties();
    }
}
