using NM.ValueDataRefWrapper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PeriodicalEvent : MonoBehaviour
{
    [Header("Design")]
    [SerializeField]
    floatVariable period;
    [SerializeField]
    TimeFrame timeframe;

    [SerializeField]
    bool shouldRunOnce;
    [SerializeField]
    bool shouldAutoRun;
    [SerializeField]
    bool shouldResetOnDisable;
    float tIncrement
    {
        get
        {
            switch (timeframe)
            {
                case TimeFrame.frameDeltaTime: return Time.deltaTime;
                case TimeFrame.physicsFrameTime: return Time.fixedDeltaTime;
                default: return Time.unscaledDeltaTime;
            }
        }
    }


    public float Period { get { return period.value; } }
    public float TimerProgressNormalized { get { return timePassed / (float)period.value; } }
    public bool IsCounting { get { return isCounting; } }
    public float TimePassedInThisPeriodInSeconds
    {
        get { return timePassed; }
    }
    public int CyclesPerformedAlready
    {
        get { return performedCycles; }
    }
    [SerializeField]
    floatReference TimePassedInThisPeriodInSecondsRef;


    public float CountDownValue
    {
        get { return period.value; }
    }

    [Header("Debug")]
    [SerializeField]
    bool isCounting;
    [SerializeField]
    float timePassed;
    [SerializeField]
    bool hasRunOnceSinceEnabled;
    [SerializeField]
    int performedCycles;


    public UnityEvent StartedTimerEvent;
    public UnityEvent StoppedTimerEvent;
    public UnityEvent TriggerEvent;

    public enum TimeFrame
    {
        frameDeltaTime,
        physicsFrameTime,
        unscaledTime
    }

    private void OnEnable()
    {

        if (shouldResetOnDisable)
        {
            ResetTimer();
        }
        if (shouldAutoRun)
            StartTimer();
    }


    private void OnDisable()
    {
        if (shouldResetOnDisable)
        {
            ResetTimer();
        }
    }

    //for use with Inputfields
    public void SetUp(string incomingValue)
    {
        float periodSeconds = float.Parse(incomingValue);
        period.SetValue(periodSeconds);
    }

    //for use from external scripts
    public void SetUp(float incomingValue)
    {
        period.SetValue(incomingValue);
    }

    [Button]
    public void StartTimer()
    {
        isCounting = true;
        StartedTimerEvent?.Invoke();
    }

    public void StartTimer(float inputT)
    {
        period.SetValue(inputT);
        StartTimer();
    }

    public void StartTimer(floatReference inputT)
    {
        period.AssignRefSO(inputT);
        StartTimer();
    }


    private void Update()
    {
        if (timeframe != TimeFrame.physicsFrameTime)
            UpdateRoutine();
    }

    private void FixedUpdate()
    {
        if (timeframe == TimeFrame.physicsFrameTime)
            UpdateRoutine();
    }

    void UpdateRoutine()
    {
        if (shouldRunOnce)
        {
            if (hasRunOnceSinceEnabled)
            {
                isCounting = false;
                return;
            }
        }

        if (isCounting)
        {
            timePassed += tIncrement;
            if (TimePassedInThisPeriodInSecondsRef) TimePassedInThisPeriodInSecondsRef.SetValue(timePassed);
        }

        if (timePassed > period.value)
        {
            hasRunOnceSinceEnabled = true;
            performedCycles++;
            TriggerEvent.Invoke();

            if (shouldRunOnce)
                isCounting = false;
            else
            {
                timePassed = 0;
                if (TimePassedInThisPeriodInSecondsRef) TimePassedInThisPeriodInSecondsRef.SetValue(timePassed);
            }
        }
    }


    public void PauseTimer(bool tof)
    {
        isCounting = !tof;
    }

    [Button]
    public void StopTimer()
    {
        timePassed = 0;
        if (TimePassedInThisPeriodInSecondsRef) TimePassedInThisPeriodInSecondsRef.SetValue(timePassed);
        isCounting = false;
        StoppedTimerEvent?.Invoke();
    }

    [Button]
    public void ResetTimer()
    {
        isCounting = false;
        performedCycles = 0;
        hasRunOnceSinceEnabled = false;
        StopTimer();
    }

    [Button]
    public void ForceRingTimer()
    {
        TriggerEvent.Invoke();
        ResetTimer();
    }
}
