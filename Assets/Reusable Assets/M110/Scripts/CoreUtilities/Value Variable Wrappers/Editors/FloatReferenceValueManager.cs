using NM.ValueDataRefWrapper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FloatReferenceValueManager : MonoBehaviour
{
    [SerializeField]
    floatReference floatValue;
    [SerializeField]
    float defaultValue;
    [SerializeField]
    float maximumPossible;

    [SerializeField]
    float minimumPossible;

    [SerializeField]

    Button IncreaseButton;
    [SerializeField]
    Button DecreaseButton;
    [SerializeField]

    float increment;
    [SerializeField]
    UnityEvent valueChanged;
    private void OnEnable()
    {
        //   ReSetToDefault();
        IncreaseButton.onClick.AddListener(IncreaseValue);
        DecreaseButton.onClick.AddListener(DecreaseValue);
    }
    private void OnDisable()
    {
        IncreaseButton.onClick.RemoveListener(IncreaseValue);
        DecreaseButton.onClick.RemoveListener(DecreaseValue);
    }

    [Button]
    public void IncreaseValue()
    {
        float targetValue = floatValue.Value + increment;
        targetValue = Mathf.Clamp(targetValue, targetValue, maximumPossible);
        floatValue.SetValue(targetValue);

        UpdateButtonState(targetValue);
        valueChanged?.Invoke();
    }

    [Button]
    public void DecreaseValue()
    {
        float targetValue = floatValue.Value - increment;
        targetValue = Mathf.Clamp(targetValue, minimumPossible, targetValue);
        floatValue.SetValue(targetValue);

        UpdateButtonState(targetValue);
        valueChanged?.Invoke();
    }

    void UpdateButtonState(float targetValue)
    {
        IncreaseButton.interactable = (targetValue != maximumPossible);
        DecreaseButton.interactable = (targetValue != minimumPossible);
    }

    public void ExternalValueChangeForAnyReason()
    {
        UpdateButtonState(floatValue.Value);
        valueChanged?.Invoke();
    }

    [Button]
    public void ReSetToDefault()
    {
        floatValue.SetValue(defaultValue);

        UpdateButtonState(defaultValue);
        valueChanged?.Invoke();
    }
}
