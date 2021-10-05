using Game.Events;

public class MissionDestroySpecificObject : Mission, IMission
{    
    private int _currentSpheresAmaunt;
    private int _currentScore;

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
        TryLoseGameBySphereAmaunt(_currentSpheresAmaunt, _currentScore);
    }

    private void OnScoreUpdateHandler(object sender, TransferFilteredPlayerScoreEvent data)
    {
        switch (MissionConditions.MissionType)
        {
            case MissionType.DestroyGreenSpheres:
                _currentScore = data.GreenSphereScore;
                break;
            case MissionType.DestroyRedSpheres:
                _currentScore = data.RedSphereScore;
                break;
            case MissionType.DestroyBlueSpheres:
                _currentScore = data.BlueSphereScore;
                break;
            case MissionType.DestroyYellowSpheres:
                _currentScore = data.YellowSphereScore;
                break;
            case MissionType.DestroyWhiteSpheres:
                _currentScore = data.WhiteSphereScore;
                break;
            case MissionType.DestroyBlackSpheres:
                _currentScore = data.BlackSphereScore;
                break;
            case MissionType.DestroyMultycoloredSheres:
                _currentScore = data.MultycoloredSheres;
                break;
            case MissionType.DestroyFish:
                _currentScore = data.FishScore;
                break;

        }

        TryWinGame(_currentScore);
    }

    private void OnGameFinishWithCurrentResultHandler(object sender, GameEndWithCurrentResultEvent result)
    {
        FinishGameWithCurrentResult(_currentScore);
    }
}
