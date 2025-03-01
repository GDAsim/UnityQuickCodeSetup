/* 
 * About:
 * Provides a Quick Method to quickly measure a void function / Action execution time
 * 
 * How To Use:
 * 
 * Method 1
 * using (new DisposableStopwatch(timespan => Debug.Log($"{timespan} elapsed")))
 * {
 *      func()
 * }
 * 
 * Method 2:
 * DisposableStopwatch.Time(() => { func() }, 100000);
 * 
 * References:
 * https://stackoverflow.com/questions/232848/wrapping-stopwatch-timing-with-a-delegate-or-lambda
 */

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