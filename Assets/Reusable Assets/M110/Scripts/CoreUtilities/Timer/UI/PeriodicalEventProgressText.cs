using TMPro;
using UnityEngine;
using static TimeConverter;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PeriodicalEventProgressText : MonoBehaviour
{
    [SerializeField]
    PeriodicalEvent periodicalEvent;
    [SerializeField]
    TextMeshProUGUI textFrame;
    [SerializeField]
    bool showAsCountdown;
    [SerializeField]
    TimeDisplay timeDisplay;
    private void Awake()
    {
        textFrame = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        periodicalEvent.StoppedTimerEvent.AddListener(InitializeDisplay);
    }
    private void OnDisable()
    {
        periodicalEvent.StoppedTimerEvent.RemoveListener(InitializeDisplay);
    }

    void InitializeDisplay()
    {
        textFrame.text = "";
    }
    public void Update()
    {
        if (periodicalEvent.IsCounting) UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        float time;
        if (showAsCountdown)
        {
            time = periodicalEvent.Period - periodicalEvent.TimePassedInThisPeriodInSeconds;
        }
        else
        {
            time = periodicalEvent.TimePassedInThisPeriodInSeconds;
        }
        textFrame.text = TimeConverter.DisplaySecondsAsTime(timeDisplay, time);
    }


}
