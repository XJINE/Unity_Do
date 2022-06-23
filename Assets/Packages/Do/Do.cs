using System;
using System.Collections;
using UnityEngine;

public static class Do
{
    #region Method

    public static IEnumerator AfterSeconds(float waitTimeSec, Action action)
    {
        yield return new WaitForSeconds(waitTimeSec);

        action();
    }

    public static IEnumerator AfterSecondsRealtime(float waitTimeSec, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTimeSec);

        action();
    }

    public static IEnumerator AfterFrames(int frameCount, Action action)
    {
        for (var i = 0; i < frameCount; i++)
        {
            yield return null;
        }

        action();
    }

    public static IEnumerator After(Coroutine coroutine, Action action)
    {
        yield return coroutine;

        action();
    }

    public static IEnumerator AtFixedUpdate(Action action)
    {
        yield return new WaitForFixedUpdate();

        action();
    }

    public static IEnumerator AtEndOfFrame(Action action)
    {
        yield return new WaitForEndOfFrame();

        action();
    }

    public static IEnumerator WhenTrue(Func<bool> check, Action action)
    {
        yield return new WaitUntil(check);

        action();
    }

    public static Coroutine AfterSeconds(MonoBehaviour observer, float waitTimeSec, Action action)
    {
        return observer.StartCoroutine(Do.AfterSeconds(waitTimeSec, action));
    }

    public static Coroutine AfterSecondsRealtime(MonoBehaviour observer, float waitTimeSec, Action action)
    {
        return observer.StartCoroutine(Do.AfterSecondsRealtime(waitTimeSec, action));
    }

    public static Coroutine AfterFrames(MonoBehaviour observer, int frameCount, Action action)
    {
        return observer.StartCoroutine(Do.AfterFrames(frameCount, action));
    }

    public static Coroutine After(MonoBehaviour observer, Coroutine coroutine, Action action)
    {
        return observer.StartCoroutine(Do.After(coroutine, action));
    }

    public static Coroutine AtFixedUpdate(MonoBehaviour observer, Action action)
    {
        return observer.StartCoroutine(Do.AtFixedUpdate(action));
    }

    public static Coroutine AtEndOfFrame(MonoBehaviour observer, Action action)
    {
        IEnumerator enumerator = Do.AtEndOfFrame(action);
        return observer.StartCoroutine(enumerator);
    }

    public static Coroutine WhenTrue(MonoBehaviour observer, Func<bool> check, Action action)
    {
        return observer.StartCoroutine(Do.WhenTrue(check, action));
    }

    #endregion Method
}