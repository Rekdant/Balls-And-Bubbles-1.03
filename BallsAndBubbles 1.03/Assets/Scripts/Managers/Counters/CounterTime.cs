using System.Collections;
using UnityEngine;
using Game.Events;

public class CounterTime : MonoBehaviour
{
    private const int UpdateInterval = 1;

    private float _currentTime;   

    private MissionConditions MissionCondition
    {
        get { return ServiceLocator.Resolve<MissionConditions>(); }
    }

    private void Awake()
    {
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        EventAggregator.Subscribe<TimerAddVolueEvent>(OnTimeAddValueHandler);
    }

    private void UnsubscribeFromEvents()
    {
        EventAggregator.Subscribe<TimerAddVolueEvent>(OnTimeAddValueHandler);
    }

    private void Start()
    {
        DefineCountdownMode();
    }

    public void OnTimeAddValueHandler(object sender, TimerAddVolueEvent changeTimer)
    {
        _currentTime += changeTimer.Value;
    }

    private void DefineCountdownMode()
    {
        switch (MissionCondition.MissionType)
        {
            case MissionType.DestroySpheresInTime:
                _currentTime = MissionCondition.StartTime;
                StartCoroutine(CountDown(-UpdateInterval));
                break;
            default:
                _currentTime = 0;
                StartCoroutine(CountDown(UpdateInterval));
                break;
        }
    }

    private IEnumerator CountDown(int updateInterval)
    {
        yield return new WaitForEndOfFrame();

        while (true)
        {
            PostTime();
            _currentTime += updateInterval;
            yield return new WaitForSeconds(UpdateInterval);           
        }
    }    

    private void PostTime()
    {
        EventAggregator.Post(this, new TransferFilteredTimeEvent { Value = Mathf.FloorToInt(_currentTime) });
    }
}
