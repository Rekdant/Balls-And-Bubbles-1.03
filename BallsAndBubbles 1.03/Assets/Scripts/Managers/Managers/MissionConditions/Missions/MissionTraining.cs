using Game.Events;

public class MissionTraining : IMission
{
    private MissionConditions MissionConditions
    {
        get { return ServiceLocator.Resolve<MissionConditions>(); }
    }

    public void SubscribeToEvent()
    {
        EventAggregator.Subscribe<TransferFilteredSphereAmauntEvent>(OnLossConditionsCheckHandler);
    }

    public void UnsubscribeFromEvent()
    {
        EventAggregator.Unsubscribe<TransferFilteredSphereAmauntEvent>(OnLossConditionsCheckHandler);
    }

    private void OnLossConditionsCheckHandler(object sender, TransferFilteredSphereAmauntEvent sphereCount)
    {
        if (sphereCount.Value >= MissionConditions.MaxSpheresByScene)
        {
            EventAggregator.Post(this, new GameLoseEvent { });           
        }
    }    
}
