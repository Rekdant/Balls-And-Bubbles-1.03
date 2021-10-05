using Game.Events;

public class MissionDestroySpheresStack : Mission, IMission
{
    private int _progress;
    private int _currentSpheresAmaunt;
    private int _currentGreenScore;
    private int _currentRedScore;
    private int _currentBlueScore;
    private int _currentYellowScore;
    private int _currentWhiteScore;
    private int _currentBlackScore;

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
        TryLoseGameBySphereAmaunt(_currentSpheresAmaunt, _progress);
    }

    private void OnScoreUpdateHandler(object sender, TransferFilteredPlayerScoreEvent sphereScore)
    {
        _currentGreenScore = sphereScore.GreenSphereScore;
        _currentRedScore = sphereScore.RedSphereScore;
        _currentBlueScore = sphereScore.BlueSphereScore;
        _currentYellowScore = sphereScore.YellowSphereScore;
        _currentWhiteScore = sphereScore.WhiteSphereScore;
        _currentBlackScore = sphereScore.BlackSphereScore;

        DetermineProgress();
    }

    private void DetermineProgress()
    {
        _progress = 0;

        if (_currentGreenScore >= MissionConditions.ValueToThreeStarsLevelComplit)
            _progress++;
        if (_currentRedScore >= MissionConditions.ValueToThreeStarsLevelComplit)
            _progress++;
        if (_currentBlueScore >= MissionConditions.ValueToThreeStarsLevelComplit)
            _progress++;
        if (_currentYellowScore >= MissionConditions.ValueToThreeStarsLevelComplit)
            _progress++;
        if (_currentWhiteScore >= MissionConditions.ValueToThreeStarsLevelComplit)
            _progress++;
        if (_currentBlackScore >= MissionConditions.ValueToThreeStarsLevelComplit)
            _progress++;

        TryWinGame(_progress);
    }

    private void OnGameFinishWithCurrentResultHandler(object sender, GameEndWithCurrentResultEvent result)
    {
        FinishGameWithCurrentResult(_progress);
    }

    private new void TryWinGame(int progress)
    {
        if (progress == MissionConditions.StacksForThreeStarsLevelComplite)
            FinishGameWithCurrentResult(_progress);
    }   

    private new void FinishGameWithCurrentResult(int progress)
    {
        if(progress == MissionConditions.StacksForOneStarLevelComplite)
            EventAggregator.Post(this, new GameWinEvent { StarsAmaunt = 1 });
        else if (progress == MissionConditions.StacksForTwoStarsLevelComplite)
            EventAggregator.Post(this, new GameWinEvent { StarsAmaunt = 2 });
        else if (progress == MissionConditions.StacksForThreeStarsLevelComplite)
            EventAggregator.Post(this, new GameWinEvent { StarsAmaunt = 3 });
        else
            EventAggregator.Post(this, new GameLoseEvent { });
    }
}
