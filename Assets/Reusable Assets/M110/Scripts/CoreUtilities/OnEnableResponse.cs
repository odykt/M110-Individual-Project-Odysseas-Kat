using UnityEngine;
using UnityEngine.Events;

public class OnEnableResponse : MonoBehaviour
{
    [SerializeField]
    float delay;
    [SerializeField]
    UnityEvent onEnableResponseEvent;

    [SerializeField]
    bool shouldRunOncePerSession;

    bool hasRunOnce;

    public void OnEnable()
    {
        if (shouldRunOncePerSession)
        {
            if (hasRunOnce) { return; }
        }
        if (delay == 0)
            EventInvoke();
        else
        {
            Invoke("EventInvoke", delay);
        }
    }

    public void EventInvoke()
    {
        onEnableResponseEvent?.Invoke();
        hasRunOnce = true;
    }

}
