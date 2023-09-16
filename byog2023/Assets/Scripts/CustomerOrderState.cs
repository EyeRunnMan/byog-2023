using UnityEngine;
using UnityEngine.Events;

public class CustomerOrderState : MonoBehaviour
{
    public float currentWaitTime;
    public const float totalWaitTime = 60f;

    public const float maxHappinessMeter = 100;
    public float currentHapinessValue;

    public UnityEvent OnTimerStart;
    bool isInOrderintState;
    bool isOutOfWaitTime;

    public UnityEvent OnTimerEnd;
    public UnityEvent<float> OnHappinessUpdated;
    public UnityEvent<float> OnTimerUpdated;


    public bool IsLifeCycelEnded;

    private void Awake()
    {
        currentWaitTime = 0;
        isInOrderintState = false;
    }

    [ContextMenu("StartTimer")]
    private void StartWaitTimer()
    {
        currentWaitTime = 0;
        OnTimerStart?.Invoke();
        isInOrderintState = true;
        isOutOfWaitTime = false;
    }

    private void Update()
    {
        if (IsLifeCycelEnded)
        {
            return;
        }

        if (isOutOfWaitTime)
        {
            OnTimerEnd?.Invoke();

            IsLifeCycelEnded = true;
        }

        if (isInOrderintState)
        {
            currentWaitTime += Time.deltaTime;

            currentHapinessValue = currentWaitTime / totalWaitTime * maxHappinessMeter;

            OnTimerUpdated?.Invoke(currentWaitTime);
            OnHappinessUpdated?.Invoke(currentHapinessValue);

            if (currentWaitTime > totalWaitTime)
            {
                isOutOfWaitTime = true;
            }
        }
    }

}