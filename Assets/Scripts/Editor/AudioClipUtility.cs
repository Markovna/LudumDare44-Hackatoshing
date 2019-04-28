using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Animations;

public static class AudioClipUtility
{

    [MenuItem("Assets/Add to GameAudioSettings/Rhythms/Level Normal")]
    public static void ConvertToRythmNormal()
    {
        ConvertToRythm(0);
    }

    [MenuItem("Assets/Add to GameAudioSettings/Rhythms/Level Hard")]
    public static void ConvertToRythmHard()
    {
        ConvertToRythm(1);
    }

    public static void ConvertToRythm(int _Level)
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
            string assetPath = AssetDatabase.GetAssetPath(selectedObjects[c]);
            var bundle = AssetDatabase.LoadAllAssetRepresentationsAtPath(assetPath);
            if (bundle != null)
            {
                foreach (var obj in bundle)
                {
                    if (obj is AnimationClip)
                    {
                        AnimationClip clip = obj as AnimationClip;

                        RythmInfo rythm = ScriptableObject.CreateInstance<RythmInfo>();
                        rythm.name = selectedObjects[c].name;
                        SerializedObject rythmObject = new SerializedObject(rythm);
                        EditorCurveBinding[] curveBindings = AnimationUtility.GetCurveBindings(clip);
                        foreach (var binding in curveBindings)
                        {
                            if (binding.propertyName == "m_LocalPosition.y")
                            {
                                AnimationCurve curve = AnimationUtility.GetEditorCurve(clip, binding);
                                foreach (var key in curve.keys)
                                {
                                    if (!Mathf.Approximately(key.value, 0f))
                                    {
                                        SerializedProperty prop = rythmObject.FindProperty("m_Ticks");
                                        prop.arraySize++;
                                        prop.GetArrayElementAtIndex(prop.arraySize - 1).floatValue = key.time;
                                    }
                                }
                            }
                        }

                        rythmObject.ApplyModifiedProperties();
                        //string ap = AssetDatabase.GetAssetPath(clip);
                        //int slash = ap.LastIndexOf("/");
                        //string newPath = ap.Remove(slash + 1, ap.Length - slash - 1) + selectedObjects[c].name + ".asset";
                        //AssetDatabase.CreateAsset(rythm, newPath);

                        EditorUtility.AddToRythmStore(rythm, _Level);
                    }
                }
            }
        }

        Selection.activeInstanceID = GameAudioSettings.Instance.GetInstanceID();

        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }
}
