using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PeriodicalEventImage : MonoBehaviour
{
    [SerializeField]
    PeriodicalEvent periodicalEvent;

    [SerializeField]
    Image image;

    [SerializeField]
    bool showAsCountdown;

    private void Awake()
    {
        image = GetComponent<Image>();
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
        if (showAsCountdown)
        {
            image.fillAmount = 1 - periodicalEvent.TimerProgressNormalized;
        }
        else
        {
            image.fillAmount = 1;
        }
    }
    public void Update()
    {
        if (periodicalEvent.IsCounting) UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        image.fillAmount = periodicalEvent.TimerProgressNormalized;
    }
}
