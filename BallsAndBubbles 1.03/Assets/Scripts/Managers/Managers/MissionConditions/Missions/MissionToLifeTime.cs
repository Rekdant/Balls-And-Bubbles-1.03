using Game.Events;

public class MissionToLifeTime : Mission, IMission
{   
    private int _currentSpheresAmaunt;
    private int _currentTime;

    public void SubscribeToEvent()
    {
        EventAggregator.Subscribe<TransferFilteredSphereAmauntEvent>(OnSpheresAmauntOnSceneUpdateHandler);
        EventAggregator.Subscribe<TransferFilteredTimeEvent>(OnTimeUpdateHandler);
        EventAggregator.Subscribe<GameEndWithCurrentResultEvent>(OnGameFinishWithCurrentResultHandler);
    }

    public void UnsubscribeFromEvent()
    {
        EventAggregator.Unsubscribe<TransferFilteredSphereAmauntEvent>(OnSpheresAmauntOnSceneUpdateHandler);
        EventAggregator.Unsubscribe<TransferFilteredTimeEvent>(OnTimeUpdateHandler);
        EventAggregator.Unsubscribe<GameEndWithCurrentResultEvent>(OnGameFinishWithCurrentResultHandler);
    }

    private void OnSpheresAmauntOnSceneUpdateHandler(object sender, TransferFilteredSphereAmauntEvent data)
    {
        _currentSpheresAmaunt = data.Value;
        TryLoseGameBySphereAmaunt(_currentSpheresAmaunt, _currentTime);
    }

    private void OnTimeUpdateHandler(object sender, TransferFilteredTimeEvent data)
    {
        _currentTime = data.Value;
        TryWinGame(_currentTime);
    }

    private void OnGameFinishWithCurrentResultHandler(object sender, GameEndWithCurrentResultEvent result)
    {
        FinishGameWithCurrentResult(_currentTime);
    }
}