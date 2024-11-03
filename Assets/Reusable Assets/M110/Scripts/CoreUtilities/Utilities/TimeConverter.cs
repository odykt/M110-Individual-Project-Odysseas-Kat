
using System;


public class TimeConverter
{
    public enum TimeDisplay
    {
        minutes,
        seconds,
        hours
    }
    public static long MicroToSeconds(long input)
    { return input / (long)Math.Pow(10, 6); }

    public static long MicroToMilli(long input)
    { return input / (long)Math.Pow(10, 3); }

    public static TimeSpan SecondsToTimeSpan(long seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        return timeSpan;
    }

    public static TimeSpan SecondsToTimeSpan(float seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        return timeSpan;
    }

    public static DateTime AddSecondsToDateTime(DateTime input, long seconds)
    {
        return input.AddSeconds(seconds);
    }


    public static DateTime ConvertEpochToDateTime(long stamp)
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(MicroToMilli(stamp));
    }

    public static DateTime ConvertDateTimeUTCToLocal(DateTime input)
    {
        return input.ToLocalTime();
    }

    public static string DisplayDateTimeDefaultSystemMethod(DateTime input)
    {
        return input.ToString();
    }

    public static string DisplayTimeSpanDefaultSystemMethod(TimeSpan input)
    {
        return input.ToString();
    }
    public static string DisplayTimeAs24H(DateTime input)
    {
        return input.ToString("HH:mm");
    }
    public static string DisplayTimeAsSubsecond(DateTime input)
    {
        return input.ToString("ss.fff");
    }
    public static string DisplayTimeAsTimeStamp(DateTime input)
    {
        return input.ToString("HH:mm:ss:fff");
    }
    public static string DisplayDateAsYYMMDD(DateTime input)
    {
        return input.ToString("yy-MMM-dd");
    }


    public static string DisplaySecondsAsTime(TimeDisplay timeDisplay, float seconds)
    {
        switch (timeDisplay)
        {
            case TimeDisplay.minutes:
                return TimeConverter.SecondsToTimeSpan(seconds).ToString("mm\\:ss");

            case TimeDisplay.seconds:
                return TimeConverter.SecondsToTimeSpan(seconds).ToString("mm\\:ss\\:ff");
            default:
                return "";
        }
    }
}