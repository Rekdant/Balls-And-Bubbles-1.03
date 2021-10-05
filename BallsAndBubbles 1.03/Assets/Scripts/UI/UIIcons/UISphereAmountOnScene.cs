using Game.Events;
using UnityEngine;

public class UISphereAmountOnScene : UIPlayWindowInfo
{
    private const int RedColorCoefficient = 15;
    private const int YellowColorCoefficient = 10;

    protected override void SubscribeToEvents()
    {
        EventAggregator.Subscribe<TransferFilteredSphereAmauntEvent>(OnSphereAmauntChangedHandler);
    }

    protected override void UnsubscribeFromEvents()
    {
        EventAggregator.Unsubscribe<TransferFilteredSphereAmauntEvent>(OnSphereAmauntChangedHandler);
    }

    private void OnSphereAmauntChangedHandler(object sender, TransferFilteredSphereAmauntEvent sphereAmaunt)
    {
        switch (MissionConditions.MissionType)
        {
            case MissionType.DestroySpheresInTime:
                SetText("--");
                break;
            default:
                DisplayInfo(sphereAmaunt.Value);
                break;
        }
    }

    protected override void DisplayInfo(int currentSphereAmaunt)
    {
        SetText($"{currentSphereAmaunt}/{MissionConditions.MaxSpheresByScene}");

        if (currentSphereAmaunt >= RedColorCoefficient)
        {           
            SetColor(Color.red);
        }
        else if (currentSphereAmaunt >= YellowColorCoefficient)
        {
            SetColor(Color.yellow);
        }
        else
        {
            SetColor(Color.green);
        }

        Animate();
    }
}
