using Game.Events;

public class MissionDestroySpheresInTime : Mission, IMission
{
    private int _currentTime;
    private int _currentSphereScore;

    public void SubscribeToEvent()
    {
        EventAggregator.Subscribe<TransferFilteredTimeEvent>(OnTimeUpdateHandler);
        EventAggregator.Subscribe<TransferFilteredPlayerScoreEvent>(OnScoreUpdateHandler);
        EventAggregator.Subscribe<GameEndWithCurrentResultEvent>(OnGameFinishWithCurrentResultHandler);
    }

    public void UnsubscribeFromEvent()
    {
        EventAggregator.Unsubscribe<TransferFilteredTimeEvent>(OnTimeUpdateHandler);
        EventAggregator.Unsubscribe<TransferFilteredPlayerScoreEvent>(OnScoreUpdateHandler);
        EventAggregator.Unsubscribe<GameEndWithCurrentResultEvent>(OnGameFinishWithCurrentResultHandler);
    }

    private void OnTimeUpdateHandler(object sender, TransferFilteredTimeEvent time)
    {
        _currentTime = time.Value;

        if (_currentTime <= 0)
        {
            FinishGameWithCurrentResult(_currentSphereScore);
        }
    }

    private void OnScoreUpdateHandler(object sender, TransferFilteredPlayerScoreEvent sphereScore)
    {
        EventAggregator.Post(this, new TimerAddVolueEvent { Value = MissionConditions.AddedTime });

        _currentSphereScore = sphereScore.TotalScore;
        TryWinGame(_currentSphereScore);
    }

    private void OnGameFinishWithCurrentResultHandler(object sender, GameEndWithCurrentResultEvent result)
    {
        FinishGameWithCurrentResult(_currentSphereScore);
    }
}

