# Unity_Do

``Do`` provides some functions to do something which you want with delay.

## Import to Your Project

You can import this asset from UnityPackage.

- [Do.unitypackage](https://github.com/XJINE/Unity_Do/blob/master/Do.unitypackage)

## How to Use

``Do`` provieds following functions.

| Function                | About                                                                    |
| ----------------------- | ------------------------------------------------------------------------ |
| Do.AfterSeconds         | Do after specified seconds.                                              |
| Do.AfterSecondsRealtime | Do after seconds. This functions ignore time.scale.                      |
| Do.AfterFrames          | Do somthing after specified frame counts.                                |
| Do.After                | Do after another coroutine.                                              |
| Do.AtFixedUpdate        | Do at ``FixedUpdate()``. ``FixedUpdate()`` will be called before ``Update()`` in next frame. |
| Do.AtEndOfFrame         | Do at ``EndOfFrame()``. ``EndOfFrame()`` will be called after ``OnGUI()``.                   |
| Do.WhenTrue             | Do when specified formula returns true.                                  |

One of a sample is like this. All of samples are shown in ``Sample.cs``.

```csharp
// Args (obserber, waitTimeSec, action)
Do.AfterSeconds(this, 1.5f, () => { Debug.Log("Do.AfterSeconds"); });
```

## Limitation

``Do`` is coded with coroutine. So almost functions will make at least 1 frame delay.
Ex. ``Do.AfterSeconds(this, 0, ()=>{})`` will not be done in same frame.
