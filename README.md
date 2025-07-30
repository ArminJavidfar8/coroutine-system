# Coroutine System

A flexible and easy-to-use Coroutine system for Unity, abstracting away the need for MonoBehaviour inheritance to start and stop coroutines. This system provides a clean interface for managing asynchronous operations, including delayed tasks and actions at the next frame.

# Features

- **Decoupled Coroutine Management**: Start and stop coroutines from any class, eliminating the need for MonoBehaviour inheritance.
- **Centralized Coroutine Holder**: Automatically creates a persistent GameObject to manage all coroutines, ensuring they continue to run even if the calling object is destroyed.
- **Delayed Task Execution**: Easily execute an Action after a specified delay.
- **Next Frame Execution**: Run an Action at the very next frame.

# How to Use

1. **Initialize the Coroutine Service**  
   First, you'll need an instance of `CoroutineService`. You can instantiate it wherever you need to start managing coroutines, typically in a central manager or a dependency injection setup.
```csharp
using YekGames.CoroutineSystem.Abstractio;
using YekGames.CoroutineSystem.Core;

public class GameManager : MonoBehaviour
{
    private ICoroutineService _coroutineService;

    void Awake()
    {
        _coroutineService = new CoroutineService();
    }
}
```
2. **Starting a Coroutine**  
   You can start any `IEnumerator` as a coroutine using the `StartCoroutine` method:
```csharp
public class AnotherClass
{
    private ICoroutineService _coroutineService;
    private Coroutine _myRunningCoroutine;

    public AnotherClass(ICoroutineService coroutineService)
    {
        _coroutineService = coroutineService;
    }

    public void StartAndStopCoroutine()
    {
        _myRunningCoroutine = _coroutineService.StartCoroutine(MyStoppableRoutine());
        // ... sometime later
        _coroutineService.StopCoroutine(_myRunningCoroutine);
    }

    private IEnumerator MyStoppableRoutine()
    {
        while (true)
        {
            Debug.Log("Coroutine is running...");
            yield return null;
        }
    }
}
```
4. **Starting a Delayed Task**  
   Execute a specific `Action` after a set amount of time:

```csharp
public class TimerExample
{
    private ICoroutineService _coroutineService;

    public TimerExample(ICoroutineService coroutineService)
    {
        _coroutineService = coroutineService;
    }

    public void StartDelayedAction()
    {
        _coroutineService.StartDelayedTask(3.0f, () => {
            Debug.Log("This message appeared after 3 seconds!");
        });
    }
}
```
5. **Executing a Task at the Next Frame**  
   Perform an `Action` at the beginning of the very next frame:
```csharp
public class NextFrameExample
{
    private ICoroutineService _coroutineService;

    public NextFrameExample(ICoroutineService coroutineService)
    {
        _coroutineService = coroutineService;
    }

    public void ScheduleNextFrameAction()
    {
        Debug.Log("Current frame action.");
        _coroutineService.DoTaskAtNextFrame(() => {
            Debug.Log("This action runs on the next frame!");
        });
    }
}
```
