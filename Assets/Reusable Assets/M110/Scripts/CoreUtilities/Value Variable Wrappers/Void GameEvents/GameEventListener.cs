using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventVariable gameEvent;
    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent responseEvent;

    [Tooltip("Delay - option A")]
    [SerializeField]
    float invokeDelay;
    [Tooltip("Delay - option B")]
    [SerializeField]
    bool randomizeDelay;
    [SerializeField]
    Vector2 timeRange;


    bool isPendingFlag;
    float randomDelay
    {
        get { return UnityEngine.Random.Range(timeRange.x, timeRange.y); }
    }
    public void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    public void OnDisable()
    {
        CancelInvoke();
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        if (!isPendingFlag)
        {
            //   Debug.Log(name + " has heard the event " + gameEvent.name + " being raised and responded with a " + responseEvent.GetPersistentMethodName(0));
            if (!randomizeDelay)
            {
                Invoke("ConditionalInvoke", invokeDelay);
            }
            else
            {
                Invoke("ConditionalInvoke", randomDelay);
            }

            isPendingFlag = true;
        }
    }

    void ConditionalInvoke()
    {
        isPendingFlag = false;
        if (responseEvent.GetPersistentEventCount() > 0)
            //  Debug.Log(gameObject.name + " responded with a " + responseEvent.GetPersistentMethodName(0) + " to the event " + gameEvent.ToString()) ;
            responseEvent?.Invoke();
    }
}
