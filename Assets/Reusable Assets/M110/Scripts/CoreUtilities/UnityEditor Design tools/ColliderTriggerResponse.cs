using UnityEngine;
using UnityEngine.Events;

public class ColliderTriggerResponse : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

#pragma warning disable
    [SerializeField]
    string tag;
#pragma warning enable
    [SerializeField]
    GameEventVariable enter;

    [SerializeField]
    UnityEvent enterE;
    [SerializeField]
    GameEventVariable exit;
    [SerializeField]
    UnityEvent exitE;


    void OnTriggerEnter(Collider collision)
    {
        if (!string.IsNullOrEmpty(tag))
        {
            if (collision.tag != tag)
            //_listener.OnCollisionEnter(collision);
            {
                return;
            }
        }
        
        
            enter?.Raise();
            enterE?.Invoke();
        
    }
    void OnTriggerExit(Collider collision)
    {
        if (!string.IsNullOrEmpty(tag))
        {
            if (collision.tag != tag)

            {
                return;
            }
        }
        exit?.Raise();
        exitE?.Invoke();
    }
}