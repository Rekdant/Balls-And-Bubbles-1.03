using Game.Events;
using UnityEngine;

public enum UIIconType
{
    GreenSphere,
    RedSphere,
    BlueSphere,
    YellowSphere,
    WhiteSphere,
    BlackSphere,
    MultycoloredSphere,
    Fish,
}

public class UIIcon : UIPlayWindowInfo
{
    [SerializeField] private UIIconType _iconType;

    protected override void SubscribeToEvents()
    {
        EventAggregator.Subscribe<TransferFilteredPlayerScoreEvent>(OnPlayerScoreChangedHandler);
    }

    protected override void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<TransferFilteredPlayerScoreEvent>(OnPlayerScoreChangedHandler);
    }

    private void OnPlayerScoreChangedHandler(object sender, TransferFilteredPlayerScoreEvent playerScore)
    {
        switch (_iconType)
        {
            case UIIconType.GreenSphere:
                DisplayInfo(playerScore.GreenSphereScore);
                break;
            case UIIconType.RedSphere:
                DisplayInfo(playerScore.RedSphereScore);
                break;
            case UIIconType.BlueSphere:
                DisplayInfo(playerScore.BlueSphereScore);
                break;
            case UIIconType.YellowSphere:
                DisplayInfo(playerScore.YellowSphereScore);
                break;
            case UIIconType.WhiteSphere:
                DisplayInfo(playerScore.WhiteSphereScore);
                break;
            case UIIconType.BlackSphere:
                DisplayInfo(playerScore.BlackSphereScore);
                break;
            case UIIconType.MultycoloredSphere:
                DisplayInfo(playerScore.MultycoloredSheres);
                break;
            case UIIconType.Fish:
                DisplayInfo(playerScore.FishScore);
                break;
        }        
    }
}
