using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PeriodicalEventSlider : MonoBehaviour
{
    [SerializeField]
    PeriodicalEvent periodicalEvent;

    [SerializeField]
    Slider slider;

    [SerializeField]
    bool showAsCountdown;

    private void Awake()
    {
        slider = GetComponent<Slider>();
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
        slider.value = 0;
    }

    public void Update()
    {
        if (periodicalEvent.IsCounting) UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (showAsCountdown)
        {
            slider.value = 1 - periodicalEvent.TimerProgressNormalized;
        }
        else
        {
            slider.value = periodicalEvent.TimerProgressNormalized;
        }
    }

}
