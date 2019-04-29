using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] float m_RangeX;
    [SerializeField] float m_RangeY;

    [SerializeField] Vector3 m_BaseRotationX;
    [SerializeField] Vector3 m_BaseRotationY;

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
        m_TransormX.localRotation = Quaternion.Euler(m_BaseRotationX) * Quaternion.AngleAxis(m_MousePosition.y * m_RangeX, Vector3.right);
        m_TransormY.localRotation = Quaternion.Euler(m_BaseRotationY) * Quaternion.AngleAxis(m_MousePosition.x * m_RangeY, Vector3.up);
    }
}
