using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class PeriodicalEventCyclesText : MonoBehaviour
{
    [SerializeField]
    PeriodicalEvent periodicalEvent;
    [SerializeField]
    TextMeshProUGUI textFrame;

    private void Awake()
    {
        textFrame = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        periodicalEvent.TriggerEvent.AddListener(UpdateDisplay);
    }
    private void OnDisable()
    {
        periodicalEvent.TriggerEvent.RemoveListener(UpdateDisplay);
    }

    public void UpdateDisplay()
    {
        textFrame.text = periodicalEvent.CyclesPerformedAlready.ToString();
    }
}