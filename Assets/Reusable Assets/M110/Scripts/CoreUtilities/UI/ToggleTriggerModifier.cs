using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleTriggerModifier : MonoBehaviour
{
    public enum TriggerMode
    {
        onlyTriggerOnTrue,
        onlyTriggerOnFalse
    }

    [SerializeField]
    Toggle toggle;
    [SerializeField]
    TriggerMode triggermode;

    [SerializeField]
    UnityEvent triggerEvent;
    private void Awake()
    {

        if (toggle == null) { toggle = GetComponent<Toggle>(); }
        if (toggle == null) { Debug.LogError(this.name + " has not been assigned a toggle."); }
    }

    private void OnEnable()
    {
        toggle.onValueChanged.AddListener(ConditionalTrigger);
    }
    private void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(ConditionalTrigger);
    }

    void ConditionalTrigger(bool tof)
    {
        if (triggermode == TriggerMode.onlyTriggerOnTrue)
        {
            if (tof) triggerEvent?.Invoke();
            return;
        }

        if (triggermode == TriggerMode.onlyTriggerOnFalse)
        {
            if (!tof) triggerEvent?.Invoke();
            return;
        }

    }
}
