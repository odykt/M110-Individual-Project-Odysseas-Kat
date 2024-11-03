using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionReferenceResponse : MonoBehaviour
{
    [SerializeField]
    InputActionReference inputAction;
    [SerializeField]
    UnityEvent unityEvent;

    private void OnEnable()
    {
        inputAction.action.Enable();
        inputAction.action.performed += PerformedResponse;
    }
    private void OnDisable()
    {
        inputAction.action.Disable();
        inputAction.action.performed -= PerformedResponse;
    }


    void PerformedResponse(InputAction.CallbackContext callbackContext)
    {
        unityEvent?.Invoke();
    }
}
