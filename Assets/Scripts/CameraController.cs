using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] float m_RangeX;
    [SerializeField] float m_RangeY;

    [SerializeField] Transform m_TransormX;
    [SerializeField] Transform m_TransormY;

    Vector2 m_MousePosition;

    private void OnGUI()
    {
        m_MousePosition = Event.current.mousePosition;

        m_MousePosition.x = (m_MousePosition.x - Screen.width * 0.5f) / Screen.width;
        m_MousePosition.y = (m_MousePosition.y - Screen.height * 0.5f) / Screen.height;
    }

    private void LateUpdate()
    {
        m_TransormX.localEulerAngles = new Vector3(m_MousePosition.y * m_RangeY, 0f, 0f);
        m_TransormY.localEulerAngles = new Vector3(0f, m_MousePosition.x * m_RangeX, 0f);
    }
}
