using Game.Events;

public class Mission
{
    protected MissionConditions MissionConditions
    {
        get { return ServiceLocator.Resolve<MissionConditions>(); }
    }

    protected void TryLoseGameBySphereAmaunt(int sphereAmaunt, int score)
    {
        if (MissionConditions.MaxSpheresByScene <= sphereAmaunt)
        {
            FinishGameWithCurrentResult(score);
        }
    }

    protected void TryWinGame(int score)
    {
        if (MissionConditions.GetExecutionStation(score) == ExecutionStatus.ThreeStars)
        {
            FinishGameWithCurrentResult(score);
        }
    }

    protected void FinishGameWithCurrentResult(int value)
    {
        switch (MissionConditions.GetExecutionStation(value))
        {
            case ExecutionStatus.OneStar:
                EventAggregator.Post(this, new GameWinEvent { StarsAmaunt = 1 });
                break;
            case ExecutionStatus.TwoStars:
                EventAggregator.Post(this, new GameWinEvent { StarsAmaunt = 2 });
                break;
            case ExecutionStatus.ThreeStars:
                EventAggregator.Post(this, new GameWinEvent { StarsAmaunt = 3 });
                break;
            default:
                EventAggregator.Post(this, new GameLoseEvent { });
                break;
        }
    }
}
