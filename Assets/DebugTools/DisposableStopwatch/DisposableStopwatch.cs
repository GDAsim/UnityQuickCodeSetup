/// <summary>
/// About:
/// Simple script to draw Grid on Scene in play mode
/// 
/// How To Use:
/*
    using (new DisposableStopwatch(timespan => Debug.Log($"{timespan} elapsed"))) 
    {
        func()
    }

    or 

    DisposableStopwatch.Time(() => { func() }, 100000);
 */
/// 
/// Reference:
/// https://stackoverflow.com/questions/232848/wrapping-stopwatch-timing-with-a-delegate-or-lambda
/// </summary>

using System;
using System.Diagnostics;

public class DisposableStopwatch : IDisposable
{
    readonly Stopwatch sw;
    readonly Action<TimeSpan> onFinishAction;

    public DisposableStopwatch(Action<TimeSpan> onFinishAction)
    {
        this.onFinishAction = onFinishAction;
        sw = Stopwatch.StartNew();
    }

    public static void Time(Action action, int iterations)
    {
        using (new DisposableStopwatch(timespan => UnityEngine.Debug.Log($"Done in: {timespan.Minutes} min , {timespan.Seconds} sec , {timespan.Milliseconds} ms")))
        {
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
        }
    }

    public void Dispose()
    {
        sw.Stop();
        onFinishAction(sw.Elapsed);
    }
}