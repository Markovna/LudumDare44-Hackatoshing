using UnityEngine;
using UnityEditor;

public static class EditorUtility
{
    [MenuItem("Window/Rythms Store")]
    static void OpenRythmsStore()
    {
        Selection.activeInstanceID = RythmsStore.Instance.GetInstanceID();
    }

    public static void AddToRythmStore(RythmInfo _Rythm, bool _ReplaceSameName = true)
    {
        AssetDatabase.AddObjectToAsset(_Rythm, RythmsStore.Instance);
        AssetDatabase.SaveAssets();

        SerializedObject rythmStoreObj = new SerializedObject(RythmsStore.Instance);
        SerializedProperty prop = rythmStoreObj.FindProperty("m_Rythms");

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
