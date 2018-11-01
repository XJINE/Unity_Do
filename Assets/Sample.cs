using UnityEngine;

public class Sample : MonoBehaviour
{
    private int checkCounter;
    private float startTime;
    private float startTimeReal;

    private void Awake()
    {
        // NOTE:
        // These are needed to check difference between Do.AfterSeconds & Do.AfterSecondsRealtime.
        
        Time.timeScale = 0.5f;

        this.startTime     = Time.timeSinceLevelLoad;
        this.startTimeReal = Time.realtimeSinceStartup;

        Do.AfterSeconds
        (this, 1.5f, () => { Debug.Log("Do.AfterSeconds : " + (Time.timeSinceLevelLoad - this.startTime)
                                                    + " / " + (Time.realtimeSinceStartup - this.startTimeReal)); });

        Do.AfterSecondsRealtime
        (this, 1.5f, () => { Debug.Log("Do.AfterSecondsRealTime : " + (Time.timeSinceLevelLoad - this.startTime)
                                                            + " / " + (Time.realtimeSinceStartup - this.startTimeReal)); });

        Coroutine coroutine = Do.AfterFrames
        (this, 30, () => { Debug.Log("Do.AfterFrames : " + Time.frameCount); });

        Do.After(this, coroutine, () => { Debug.Log("Do.After(Do.AfterFrames)"); });

        Do.After(this, Do.AfterSeconds(this, 3f, () => { Debug.Log("Do.After(Do.AfterSeconds)1"); }),
                                                 () => { Debug.Log("Do.After(Do.AfterSeconds)2"); });

        Do.AtFixedUpdate
        (this, () => { Debug.Log("Do.AtFixedUpdate"); });

        Do.AtEndOfFrame
        (this, () => { Debug.Log("Do.AtEndOfFrame1"); });

        // NOTE:
        // You can also use with StartCoroutine() like this.

        StartCoroutine
        (Do.AtEndOfFrame(() => { Debug.Log("Do.AtEndOfFrame2"); }));

        Do.WhenTrue
        (this, () => { return 100 < checkCounter; }, () => { Debug.Log("Do.WhenTrue"); });
    }

    private void Update()
    {
        this.checkCounter += 1;
    }

    private void OnGUI()
    {
        Debug.Log("OnGUI : Called before EndOfFrame");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate : Called before Update (in next frame)");
    }
}