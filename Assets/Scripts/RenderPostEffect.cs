using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPostEffect : MonoBehaviour
{
    [SerializeField] Material m_PixelateMaterial;

    [SerializeField] float m_LowQuality;
    [SerializeField] float m_NormalQuality;

    int m_Level;

    static RenderPostEffect m_Instance;

    private void Awake()
    {
        m_Instance = this;

        m_Level = PlayerPreferences.GraphicsLevel;
    }

    public static void SetGraphicLevel(int _Level)
    {
        m_Instance.m_Level = _Level;
    }

    void OnRenderImage(RenderTexture _Source, RenderTexture _Destination)
    {
        switch (m_Level)
        {
            case 0:
            case 1:
                SetPixelateParams(m_Level == 0 ? m_LowQuality : m_NormalQuality);
                Graphics.Blit(_Source, _Destination, m_PixelateMaterial);
                break;
            default:
                Graphics.Blit(_Source, _Destination);
                break;
        }
    }

    void SetPixelateParams(float _Quality)
    {
        Vector2 aspectRatioData;
        if (Screen.height > Screen.width)
            aspectRatioData = new Vector2((float)Screen.width / Screen.height, 1);
        else
            aspectRatioData = new Vector2(1, (float)Screen.height / Screen.width);

        int pixelDensity = (int)(Mathf.Max(Screen.width, Screen.height) * 2 * _Quality);
        m_PixelateMaterial.SetVector("_AspectRatioMultiplier", aspectRatioData);
        m_PixelateMaterial.SetInt("_PixelDensity", pixelDensity);
    }
}
