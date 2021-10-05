using Game.Events;
using UnityEngine;

public class UITime : UIPlayWindowInfo
{
    private const int RedColorValue = 10;
    private const int YellowColorValue = 20;

    protected override void SubscribeToEvents()
    {
        EventAggregator.Subscribe<TransferFilteredTimeEvent>(UpdateInfo);
    }

    protected override void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<TransferFilteredTimeEvent>(UpdateInfo);
    }

    private void UpdateInfo(object sender, TransferFilteredTimeEvent time)
    {
        switch (MissionConditions.MissionType)
        {
            case MissionType.LifeTheTime:
                base.DisplayInfo(time.Value);
                break;
            case MissionType.DestroySpheresInTime:
                DisplayInfo(time.Value);            
                break;
            default:
                SetText(time.Value.ToString());
                Animate();
                break;
        }
    }

    protected override void DisplayInfo(int time)
    {
        SetText(time.ToString());

        if (time < RedColorValue)
        {
            SetColor(Color.red);
        }
        else if (time < YellowColorValue)
        {
            SetColor(Color.yellow);
        }
        else
        {
            SetColor(Color.green);
        }
    }
}
