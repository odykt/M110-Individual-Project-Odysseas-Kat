using NM.ValueDataRefWrapper;
using UnityEngine;
using UnityEngine.UI;

public class BoolRefDisplayer : MonoBehaviour
{
    [Header("GetComponent if null")]
    [SerializeField]
    Toggle toggle;

    [Space]

    [Header("Design")]
    [SerializeField]
    boolReference boolReference;

    [SerializeField]
    bool shouldInverse;

    [Tooltip("Will also trigger the Toggle if the previous value is not the same as the incoming value")]
    [SerializeField]
    bool doNotify;

    [SerializeField]
    bool dontRunOnEnable;

    [SerializeField]
    float onEnableDelay;

    [SerializeField]
    bool runOnUpdate;

    private void Awake()
    {
        if (toggle == null)
        {
            toggle.GetComponent<Toggle>();
        }
    }

    public void OnEnable()
    {
        if (dontRunOnEnable)
            return;

        Invoke("UpdateToggle", onEnableDelay);
    }

    private void Update()
    {
        if (runOnUpdate)
        {
            UpdateToggle();
        }
    }

    public void UpdateToggle()
    {
        if (doNotify)
        {
            SetToggle();
        }
        else
            DisplayToggle();
    }

    void DisplayToggle()
    {
        if (shouldInverse)
        {
            toggle.SetIsOnWithoutNotify(!boolReference.Value);
        }
        else
            toggle.SetIsOnWithoutNotify(boolReference.Value);
    }

    void SetToggle()
    {
        if (shouldInverse)
        {
            toggle.isOn = !boolReference.Value;
        }
        else
            toggle.isOn = boolReference.Value;
    }
}
