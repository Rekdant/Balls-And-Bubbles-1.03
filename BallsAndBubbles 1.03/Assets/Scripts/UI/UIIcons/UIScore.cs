using Game.Events;

public class UIScore : UIPlayWindowInfo
{
    protected override void SubscribeToEvents()
    {
        EventAggregator.Subscribe<TransferFilteredPlayerScoreEvent>(OnPlayerScoreChangeHandler);
    }

    protected override void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<TransferFilteredPlayerScoreEvent>(OnPlayerScoreChangeHandler);
    }

    private void OnPlayerScoreChangeHandler(object sender, TransferFilteredPlayerScoreEvent playerScore)
    {
        switch (MissionConditions.MissionType)
        {
            case MissionType.DestroySpheres:
                DisplayInfo(playerScore.TotalScore);
                break;
            case MissionType.DestroySpheresInTime:
                DisplayInfo(playerScore.TotalScore);
                break;
            default:
                SetText(playerScore.TotalScore.ToString());
                Animate();
                break;
        }
    }
}
