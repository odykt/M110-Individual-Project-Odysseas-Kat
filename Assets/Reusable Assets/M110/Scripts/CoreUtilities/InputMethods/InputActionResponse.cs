using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionResponse : MonoBehaviour
{
    [SerializeField]
    InputAction inputAction;
    [SerializeField]
    UnityEvent unityEvent;

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.performed += PerformedResponse;
    }
    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.performed -= PerformedResponse;
    }


    void PerformedResponse(InputAction.CallbackContext callbackContext)
    {
        unityEvent?.Invoke();
    }
}
