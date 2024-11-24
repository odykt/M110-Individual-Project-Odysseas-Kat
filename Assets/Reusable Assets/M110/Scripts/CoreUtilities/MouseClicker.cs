using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class MouseClicker : MonoBehaviour
{
    Camera m_Camera;
    [SerializeField]
    LayerMask m_LayerMask;
    [SerializeField]
    UnityEvent mouseClickEvent;

    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left mouse click");
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_LayerMask))
            {
                Debug.Log("Raycast hit smth: " + hit.collider.name);
                if (hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("Raycast hit me");
                    mouseClickEvent?.Invoke();
                }

            }
        }
    }
}