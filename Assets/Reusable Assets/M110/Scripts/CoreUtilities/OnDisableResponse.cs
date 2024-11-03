using UnityEngine;
using UnityEngine.Events;

public class OnDisableResponse : MonoBehaviour
{
    [SerializeField]
    UnityEvent onDisableResponseEvent;

    public void OnDisable()
    {
        onDisableResponseEvent?.Invoke();
    }
}
