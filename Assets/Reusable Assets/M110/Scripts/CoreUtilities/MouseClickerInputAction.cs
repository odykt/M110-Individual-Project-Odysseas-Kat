using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class MouseClickerInputAction : MonoBehaviour
{
    Camera m_Camera;

    [SerializeField]
    InputActionReference click;
    [SerializeField]
    InputActionReference point;
    [SerializeField]
    UnityEvent unityEvent;

    void Awake()
    {
        m_Camera = Camera.main;
    }


    private void OnEnable()
    {
        click.action.performed += PerformedResponse;
    }
    private void OnDisable()
    {
        click.action.performed -= PerformedResponse;
    }


    void PerformedResponse(InputAction.CallbackContext callbackContext)
    {
        Vector2 pointerPosition = point.action.ReadValue<Vector2>();
        Ray ray = m_Camera.ScreenPointToRay(pointerPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Raycast hit smth: " + hit.collider.name);
            if (hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("Raycast hit me");
                unityEvent?.Invoke();
            }

        }
    }
 
}