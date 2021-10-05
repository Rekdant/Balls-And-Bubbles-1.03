using Game.Events;

public class MissionDestroySpheres : Mission, IMission
{    
    private int _currentSpheresAmaunt;
    private int _currentSphereScore;

    public void SubscribeToEvent()
    {
        EventAggregator.Subscribe<TransferFilteredSphereAmauntEvent>(OnSpheresAmauntOnSceneUpdateHandler);
        EventAggregator.Subscribe<TransferFilteredPlayerScoreEvent>(OnScoreUpdateHandler);
        EventAggregator.Subscribe<GameEndWithCurrentResultEvent>(OnGameFinishWithCurrentResultHandler);
    }

    public void UnsubscribeFromEvent()
    {
        EventAggregator.Unsubscribe<TransferFilteredSphereAmauntEvent>(OnSpheresAmauntOnSceneUpdateHandler);
        EventAggregator.Unsubscribe<TransferFilteredPlayerScoreEvent>(OnScoreUpdateHandler);
        EventAggregator.Unsubscribe<GameEndWithCurrentResultEvent>(OnGameFinishWithCurrentResultHandler);
    }

    private void OnSpheresAmauntOnSceneUpdateHandler(object sender, TransferFilteredSphereAmauntEvent data)
    {
        _currentSpheresAmaunt = data.Value;
        TryLoseGameBySphereAmaunt(_currentSpheresAmaunt, _currentSphereScore);
    }

    private void OnScoreUpdateHandler(object sender, TransferFilteredPlayerScoreEvent data)
    {
        _currentSphereScore = data.TotalScore;
        TryWinGame(_currentSphereScore);
    }

    private void OnGameFinishWithCurrentResultHandler(object sender, GameEndWithCurrentResultEvent result)
    {
        FinishGameWithCurrentResult(_currentSphereScore);
    }   
}
