using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class AudioClipUtility
{
    [MenuItem("Assets/Convert to clip")]
    public static void ConvertToClip()
    {
        foreach (var obj in Selection.objects)
        {
            AudioClip clip = obj as AudioClip;
            if (clip != null)
            {
                for (int i = 0; i < clip.channels; i++)
                {
                    AnimationClip animation = new AnimationClip();
                    List<AnimationEvent> events = new List<AnimationEvent>();


                    float[] samples = new float[clip.samples];
                    clip.GetData(samples, i);

                    bool boom = false;
                    for (int j = 0; j < samples.Length; j++)
                    {
                        float s = samples[j];

                        if (s > .92f && !boom)
                        {
                            boom = true;

                            AnimationEvent ev = new AnimationEvent();
                            ev.stringParameter = "boom";
                            ev.time = clip.length * (j / (float)samples.Length);

                            events.Add(ev); 
                        }
                        else
                            boom = false;
                    }

                    AnimationUtility.SetAnimationEvents(animation, events.ToArray());

                    AssetDatabase.CreateAsset(animation, AssetDatabase.GenerateUniqueAssetPath("Assets/animation.anim")); 
                }
            }

        }
    }
}
