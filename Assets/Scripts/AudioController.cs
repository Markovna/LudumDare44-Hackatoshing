using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource m_Background;
    [SerializeField] AudioSource m_Hit;
    [SerializeField] float m_HitFrequency;

    float m_LastHit;

    // Start is called before the first frame update
    void Start()
    {
        m_Background.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - m_LastHit > m_HitFrequency)
        {
            m_LastHit = Time.time;
            m_Hit.Play();
        }
    }
}
